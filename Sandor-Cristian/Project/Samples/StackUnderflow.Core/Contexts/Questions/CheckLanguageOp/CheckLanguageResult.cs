using CSharp.Choices;

namespace StackUnderflow.Domain.Schema.Questions.CheckLanguageOp
{
    [AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { }

        public class ValidationSucceeded : ICheckLanguageResult
        {
            public ValidationSucceeded(string text)
            {
                Text = text;
            }

            public string Text { get; }
        }

        public class ValidationFailed : ICheckLanguageResult
        {
            public ValidationFailed(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }

        public class ManualReviewRequired : ICheckLanguageResult
        {
            public ManualReviewRequired(string text)
            {
                Text = text;
            }

            public string Text { get; }
        }
    }
}
