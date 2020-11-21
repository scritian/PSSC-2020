using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.FrontOffice
{
    public class AnswersData
    {
        public AnswersData(Post question)
        {
            Question = question;
        }

        public Post Question { get; }
    }
}
