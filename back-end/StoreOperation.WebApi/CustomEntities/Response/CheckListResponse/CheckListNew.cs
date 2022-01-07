using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StoreOperation.WebApi.Data.Entities;
using IMapper = AutoMapper.IMapper;

namespace StoreOperation.WebApi.CustomEntities.Response.CheckListResponse
{
    public class CheckListNewResponse
    {
        public CheckListNewResponse()
        {
            
        }
        public CheckListNewResponse(Guid checkListDayId, Guid storeId, DateTime day, int rank,
            IEnumerable<CheckListQuestionGroup> groups)
        {
            CheckListDayId = checkListDayId;
            StoreId = storeId;
            Day = day;
            Rank = rank;
            Groups = new HashSet<CheckListNewGroupResponse>();
            setGroup(groups);
        }

        public Guid CheckListDayId { get; set; }
        public Guid StoreId { get; set; }
        public DateTime Day { get; set; }
        public int Rank { get; set; }

        public string Note { get; set; }
        public ICollection<CheckListNewGroupResponse> Groups { get; set; }

        private void setGroup(IEnumerable<CheckListQuestionGroup> groups)
        {
            if (groups.Any())
            {
                foreach (var questionGroup in groups)
                {
                    Groups.Add(new CheckListNewGroupResponse(questionGroup));
                }
            }
        }
    }

    public class CheckListNewGroupResponse
    {
        public CheckListNewGroupResponse()
        {
            
        }
        public CheckListNewGroupResponse(CheckListQuestionGroup group)
        {
            Name = group.Name;
            Sort = group.Sort;
            CheckListQuestionGroupId = group.CheckListQuestionGroupId;
            CheckListNewQuestions = new HashSet<CheckListNewQuestionResponse>();
            setQuestion(group.CheckListQuestions);
        }

        public Guid CheckListQuestionGroupId { get; set; }
        public ICollection<CheckListNewQuestionResponse> CheckListNewQuestions { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }

        private void setQuestion(IEnumerable<CheckListQuestion> questions)
        {
            if (questions.Any())
            {
                foreach (var question in questions)
                {
                    CheckListNewQuestions.Add(new CheckListNewQuestionResponse(question.CheckListQuestionId,
                        question.CheckListQuestionGroupId, question.Question, question.Skor, question.Sort));
                }
            }
        }
    }

    public class CheckListNewQuestionResponse
    {
        public CheckListNewQuestionResponse()
        {
            
        }
        public CheckListNewQuestionResponse(Guid checkListQuestionId, Guid checkListQuestionGroupId, string question, byte skor,
            int? sort)
        {
            CheckListQuestionId = checkListQuestionId;
            CheckListQuestionGroupId = checkListQuestionGroupId;
            Question = question;
            Skor = skor;
            Sort = sort;
            Answer = false;
            AnswerState = 2;
        }

        public Guid CheckListQuestionId { get; set; }
        public Guid CheckListQuestionGroupId { get; set; }
        public Guid CheckListId { get; set; }
        public string Question { get; set; }
        public byte Skor { get; set; }
        public int? Sort { get; set; }
        public bool Answer { get; set; }
        public byte AnswerState { get; set; }
    }
}