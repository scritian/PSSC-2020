using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Voting
{
    [AsChoice]
    public static partial class VoteResult
    {
        public interface IVoteResult { }

        public class VoteSuccessful : IVoteResult
        {
            public VoteSuccessful()
            {
            }
        }

        public class InvalidRequest : IVoteResult
        {
            public string Message { get; set; }

            public InvalidRequest(string message)
            {
                Message = message;
            }
        }

        public class VoteUpFailed : IVoteResult
        {
            public string Message { get; set; }

            public VoteUpFailed(string message)
            {
                Message = message;
            }
        }
    }
}
