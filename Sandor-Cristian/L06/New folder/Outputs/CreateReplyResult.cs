using System;
using System.Collections.Generic;
using System.Text;
using L06.Models;
using L06.Inputs;
using CSharp.Choices;

namespace L06.Outputs
{
    [AsChoice]
    public static partial class CreateReplyResult
    {
        public interface ICreateReplyResult { }

        public class ReplyValid : ICreateReplyResult
        {
            public Reply Reply { get; }

            public ReplyValid(Reply reply)
            {
                Reply = reply;
            }
        }

        public class InvalidReply : ICreateReplyResult
        {
            public string Reasons { get; }

            public InvalidReply(string reasons)
            {
                Reasons = reasons;
            }
        }

        public class InvalidRequest : ICreateReplyResult
        {
            public string ValidationErrors { get; }
            public InvalidRequest(string validationErrors)
            {
                ValidationErrors = validationErrors;
            }
        }

    }
}