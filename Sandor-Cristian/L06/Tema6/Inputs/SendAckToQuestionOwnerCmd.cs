using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Tema6.Inputs
{
    public class SendAckToQuestionOwnerCmd
    {
        [Required]
        public int ReplyId { get; }

        [Required]
        public int QuestionId { get; }

        [Required]
        public string Answer { get; }
        public string Text { get; internal set; }

        public SendAckToQuestionOwnerCmd(int ReplyId, int QuestionId, string Answer)
        {
            ReplyId = this.ReplyId;
            QuestionId = this.QuestionId;
            Answer = this.Answer;
        }
    }
}