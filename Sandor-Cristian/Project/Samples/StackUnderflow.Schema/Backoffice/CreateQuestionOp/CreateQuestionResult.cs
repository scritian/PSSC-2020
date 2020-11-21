using CSharp.Choices;
using StackUnderflow.EF.Models;

namespace StackUnderflow.Domain.Schema.Backoffice.CreateQuestionOp
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }

        public class QuestionCreated : ICreateQuestionResult
        {
            public Post Post { get; }

            public QuestionCreated(Post post)
            {
                Post = post;
            }
        }

        public class QuestionNotCreated : ICreateQuestionResult
        {
        }

        public class InvalidRequest : ICreateQuestionResult
        {
            public string Message { get; }

            public InvalidRequest(string message)
            {
                Message = message;
            }
        }
    }
}
