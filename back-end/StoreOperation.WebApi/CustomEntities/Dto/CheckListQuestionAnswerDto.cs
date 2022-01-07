using System;

namespace StoreOperation.WebApi.CustomEntities.Dto
{
    public class CheckListQuestionAnswerDto
    {
        public CheckListQuestionAnswerDto()
        {
            
        }

        public CheckListQuestionAnswerDto(bool answer, byte answerState, byte skor, Guid checkListId)
        {
            Answer = answer;
            AnswerState = answerState;
            Skor = skor;
            CheckListId = checkListId;
        }

        public bool Answer { get; set; }
        public byte AnswerState { get; set; }
        //todo: magaza kullanıcılarına kapatılacak mı?
        public byte Skor { get; set; }
        public Guid CheckListId { get; set; }
    }
}