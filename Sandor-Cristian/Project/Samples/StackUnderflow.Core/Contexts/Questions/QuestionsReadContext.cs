using StackUnderflow.Domain.Schema.Models;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class UserReadContext
    {
        public UserReadContext(IEnumerable<QuestionSummary> questions)
        {
            Questions = questions;
        }

        public IEnumerable<QuestionSummary> Questions { get; }
    }
}
