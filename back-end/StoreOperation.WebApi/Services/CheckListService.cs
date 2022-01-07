using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Common.Enums;
using StoreOperation.WebApi.Configuration.Context;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Request.CheckList;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;
using StoreOperation.WebApi.Helpers.Extensions;
using StoreOperation.WebApi.Services.Abstract;


namespace StoreOperation.WebApi.Services
{
    public class CheckListService : BaseService, ICheckListService
    {
        private readonly ICheckListDayRepository _checkListDayRepository;
        private readonly ICheckListRepository _checkListRepository;
        private readonly IAppStoreRepository _appStoreRepository;
        private readonly ICheckListQuestionGroupsRepository _questionGroupsRepository;
        private readonly ICheckListQuestionRepository _questionRepository;

        public CheckListService(
            IMapper mapper,
            ILoggerRepository loggerRepository,
            IStoreOperationConfigurationContext checkListConfigurationContext,
            ICheckListDayRepository checkListDayRepository,
            ICheckListRepository checkListRepository,
            IAppStoreRepository appStoreRepository,
            ICheckListQuestionGroupsRepository questionGroupsRepository,
            ICheckListQuestionRepository questionRepository
        ) : base(mapper, loggerRepository, checkListConfigurationContext)
        {
            _checkListDayRepository = checkListDayRepository;
            _checkListRepository = checkListRepository;
            _appStoreRepository = appStoreRepository;
            _questionGroupsRepository = questionGroupsRepository;
            _questionRepository = questionRepository;
        }

        public async Task<ApiResponse<CheckListDaysResponse>> GetCheckListDaysAsync(Guid storeId)
        {
            var current = DateTime.Now;
            bool isCurrentDay =
                await _checkListDayRepository.Any(x => x.Day.Date.CompareTo(current.Date) == 0 && x.StoreId == storeId);
            if (!isCurrentDay)
            {
                // ilgili günün CheckListDay kaydını ekliyoruz
                await _checkListDayRepository.AddAsync(new CheckListDay()
                {
                    Day = current,
                    Rank = 0,
                    State = true,
                    StoreId = storeId,
                });
            }

            var store = await _appStoreRepository.GetSingleAsync(x => x.StoreId == storeId);
            var storeDto = _mapper.Map<AppStoreDto>(store);

            var lst = await _checkListDayRepository
                .GetAllAsync(include: i => i.Include(ii => ii.CheckLists).ThenInclude(cli => cli.Certifying),
                    predicate: x => x.StoreId == storeId);

            var responseList = lst.Select(x => new CheckListDayDto(x));

            var day = new CheckListDaysResponse(storeDto, responseList.OrderByDescending(x => x.Day));
            return new SuccessApiResponse<CheckListDaysResponse>(ResponseStatus.Ok, day);
        }


        #region AddCheckListAsync

        public async Task<ApiResponse<CheckListNewResponse>> NewCheckListAsync(Guid StoreId)
        {
            var current = DateTime.Now;
            var day = current;
            var storeId = StoreId;
            var checkListDayId = Guid.Empty;
            int? rank;
            bool isCurrentDay =
                await _checkListDayRepository.Any(x => x.Day.Date == current.Date && x.StoreId == storeId);
            if (!isCurrentDay)
            {
                var newItem = new CheckListDay()
                {
                    Day = current,
                    Rank = CheckListDayRank.First.ToInt() ?? 0,
                    State = true,
                    StoreId = storeId,
                };
                // ilgili günün CheckListDay kaydını ekliyoruz
                await _checkListDayRepository.AddAsync(newItem);
                checkListDayId = newItem.CheckListDayId;
                rank = newItem.Rank;
            }
            else
            {
                var item = await _checkListDayRepository
                    .GetSingleAsync(x => x.StoreId == storeId && x.Day.Date == current.Date);
                checkListDayId = item.CheckListDayId;
                rank = (await GetRank(checkListDayId) > 1)
                    ? CheckListDayRank.Update.ToInt()
                    : CheckListDayRank.First.ToInt();
            }

            var activeGroups =
                await _questionGroupsRepository.GetAllAsync(include: x => x.Include(z => z.CheckListQuestions),
                    predicate: x => x.State == true);

            var newCheckList = new CheckListNewResponse(checkListDayId, storeId, day, rank ?? 1, activeGroups);

            return new SuccessApiResponse<CheckListNewResponse>(newCheckList);
        }

        public async Task<ApiResponse> AddCheckListAsync(CheckListNewResponse newCheckList, Guid appUserId)
        {
            if (newCheckList is not null)
            {
                var checkList = await GetCheckList(appUserId, newCheckList);

                await _checkListRepository.AddAsync(checkList);
                var day = await _checkListDayRepository.GetSingleAsync(x =>
                    x.CheckListDayId == newCheckList.CheckListDayId);
                day.Rank = await GetRank(newCheckList.CheckListDayId);
                await _checkListDayRepository.SaveASync();
                return new SuccessApiResponse(ResponseStatus.Created, "Yeni Kontrol Listesi oluşturuldu.");
            }

            return new ErrorApiResponse("Kontrol Listesi boş geldi.");
        }

        private async Task<CheckList> GetCheckList(Guid appUserId, CheckListNewResponse newCheckList)
        {
            var checkList = new CheckList();
            var ncList = newCheckList;

            List<CheckListQuestionAnswer> questions = new List<CheckListQuestionAnswer>();

            foreach (var group in ncList.Groups)
            {
                foreach (var newQuestion in group.CheckListNewQuestions)
                {
                    questions.Add(_mapper.Map<CheckListQuestionAnswer>(newQuestion));
                }
            }

            checkList.Questions = questions;
            checkList.Note = ncList.Note;
            checkList.Rank = await GetRank(ncList.CheckListDayId);
            checkList.TimeSpan = DateTime.Now;
            checkList.AppUserId = appUserId;
            checkList.CheckListDayId = ncList.CheckListDayId;
            checkList.State = true;

            return checkList;
        }

        private async Task<int> GetRank(Guid checkListDayId)
        {
            return await _checkListRepository.Count(x => x.CheckListDayId == checkListDayId);
        }

        #endregion

        #region group

        public async Task<ApiResponse> AddCheckListQuestionGroupAsync(QuestionGroupCreateRequest model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return new ErrorApiResponse(ResultMessage.CheckListQuestionGroupNameCanNotBeEmptyOrNull);
            }

            var group = _mapper.Map<CheckListQuestionGroup>(model);
            await _questionGroupsRepository.AddAsync(group);
            var result = _mapper.Map<CheckListQuestionGroupDto>(group);
            return new SuccessApiResponse<CheckListQuestionGroupDto>(ResponseStatus.Created, result,
                ResultMessage.CheckListQuestionGroupCreate);
        }

        public async Task<ApiResponse> UpdateCheckListQuestionGroupAsync(QuestionGroupUpdateRequest model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return new ErrorApiResponse(ResultMessage.CheckListQuestionGroupNameCanNotBeEmptyOrNull);
            }

            if (Guid.Empty == model.CheckListQuestionGroupId)
            {
                return new ErrorApiResponse(ResultMessage.CheckListQuestionGroupIdCanNotBeEmpty);
            }

            var group = _mapper.Map<CheckListQuestionGroup>(model);
            await _questionGroupsRepository.UpdateAsync(group);
            return new SuccessApiResponse(ResponseStatus.Ok, ResultMessage.SuccessUpdate);
        }

        public async Task<ApiResponse<IEnumerable<CheckListQuestionGroupDto>>> GetCheckListQuestionGroupsAsync()
        {
            var groups = await _questionGroupsRepository.GetInQuestionAllAsync();
            return new SuccessApiResponse<IEnumerable<CheckListQuestionGroupDto>>(ResponseStatus.Ok, groups);
        }


        public async Task<ApiResponse<IEnumerable<CheckListQuestion>>> GetCheckListQuestionInGroupAsync(Guid id)
        {
            return new SuccessApiResponse<IEnumerable<CheckListQuestion>>(
                await _questionRepository.GetAllAsync(x => x.CheckListQuestionGroupId == id));
        }

        #endregion

        public async Task<ApiResponse<IEnumerable<CheckListQuestion>>> GetCheckListQuestionAsync()
        {
            return new SuccessApiResponse<IEnumerable<CheckListQuestion>>(await _questionRepository.GetAllAsync());
        }

        public async Task<ApiResponse<QuestionDto>> AddCheckListQuestionAsync(QuestionCreateRequest model)
        {
            var item = _mapper.Map<CheckListQuestion>(model);
            await _questionRepository.AddAsync(item);
            return new SuccessApiResponse<QuestionDto>(_mapper.Map<QuestionDto>(item));
        }

        public async Task<ApiResponse> UpdateCheckListQuestionAsync(QuestionUpdateRequest model)
        {
            if (model.CheckListQuestionId == Guid.Empty || model.CheckListQuestionGroupId == Guid.Empty)
            {
                return new ErrorApiResponse(ResultMessage.CheckListQuestionIdAndGroupIdCanNotBeEmptyOrNull);
            }

            var item = _mapper.Map<CheckListQuestion>(model);
            var resultItem = _mapper.Map<QuestionDto>(await _questionRepository.UpdateAsync(item));
            return new SuccessApiResponse<QuestionDto>(resultItem);
        }

        public async Task<ApiResponse> RemoveCheckListQuestionAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new ErrorApiResponse(ResultMessage.CheckListQuestionIdCanNotBeEmpty);
            }

            var result = await _questionRepository.RemoveAsync(id);
            if (result)
            {
                return new SuccessApiResponse();
            }
            else
            {
                return new ErrorApiResponse(ResultMessage.CheckListQuestionNotPassive);
            }
        }

        public async Task<ApiResponse> RemoveCheckListQuestionInGroupAsync(IEnumerable<Guid> ids)
        {
            if (!(ids.Count() > 0))
            {
                return new ErrorApiResponse(ResultMessage.NotRemoveQuestionsInGroups);
            }

            var result = await _questionRepository.RemoveAllAsync(ids);

            if (result)
            {
                return new SuccessApiResponse();
            }
            else
            {
                return new ErrorApiResponse(ResultMessage.CheckListQuestionNotPassive);
            }
        }
    }
}