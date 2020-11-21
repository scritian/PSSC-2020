using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions
{
    public class GetQuestionCmd
    {
        public int QuestionId { get; set; }

        public GetQuestionCmd(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
