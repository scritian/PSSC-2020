using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.MarkAsReadOp
{
    [AsChoice]
    public static partial class MarkAsViewedResult
    {
        public interface IMarkAsViewedResult { }

        public class MarkAsViewedSuccessful : IMarkAsViewedResult
        {
        }

        public class CreateQuestionFailed : IMarkAsViewedResult
        {
        }

        public class InvalidRequest : IMarkAsViewedResult
        {
        }
    }
}
