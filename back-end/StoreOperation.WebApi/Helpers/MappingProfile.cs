using AutoMapper;
using StoreOperation.WebApi.CustomEntities.Dto;
using StoreOperation.WebApi.CustomEntities.Request.App;
using StoreOperation.WebApi.CustomEntities.Request.CheckList;
using StoreOperation.WebApi.CustomEntities.Request.UserRequest;
using StoreOperation.WebApi.CustomEntities.Response.AppResponse;
using StoreOperation.WebApi.CustomEntities.Response.CheckListResponse;
using StoreOperation.WebApi.Data.Entities;
using UserDto = StoreOperation.WebApi.CustomEntities.Dto.UserDto;

namespace StoreOperation.WebApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //<source,destination>
            
            CreateMap<RegisterUserRequest, AppUser>();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<AppUser, UserInfoResponse>();
            CreateMap<AppStore, CreateStore>().ReverseMap();
            CreateMap<UpdateStore, AppStore>();
            CreateMap<AppStore, AppStoreDto>()
                .ForMember(x => x.StoreName,y => y.MapFrom((z)=>z.Name) )
                .ReverseMap();
            CreateMap<CheckListDay, CheckListDayDto>().ReverseMap();
            CreateMap<CheckListQuestionGroup, CheckListQuestionGroupDto>().ReverseMap();
            CreateMap<QuestionGroupCreateRequest, CheckListQuestionGroup>();
            CreateMap<QuestionGroupUpdateRequest, CheckListQuestionGroup>();
            CreateMap<QuestionCreateRequest, CheckListQuestion>();
            CreateMap<CheckListQuestion, QuestionDto>();
            CreateMap<QuestionUpdateRequest, CheckListQuestion>();
            CreateMap<CheckListQuestion, CheckListNewQuestionResponse>();
            CreateMap<CheckListNewQuestionResponse, CheckListQuestionAnswer>().ForMember(x => x.CheckListId,opt=>opt.Ignore());
        }
    }
}
