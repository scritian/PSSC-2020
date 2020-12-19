using StackUnderflow.DatabaseModel.Models;
using System.Collections.Generic;


namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class QuestionsWriteContext
    {
        public ICollection<Question> Questions { get; }
        public ICollection<Reply> Replies { get; }
        public QuestionsWriteContext(ICollection<Question> questions)
        {
            Questions = questions ?? new List<Question>();
        }
        public QuestionsWriteContext(ICollection<Reply> replies)
        {
            Replies = replies ?? new List<Reply>();
        }
    }
}