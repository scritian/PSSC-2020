using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts
{
    public class QuestionsReadContext
    {
        public ICollection<Post> Questions;

        public QuestionsReadContext(ICollection<Post> questions)
        {
            Questions = questions;
        }
    }
}
