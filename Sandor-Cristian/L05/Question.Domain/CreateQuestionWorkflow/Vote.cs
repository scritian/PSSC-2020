using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public static partial class Vote
    {
        public interface IVote { }
        public class UnverifiedVotes : IVote
        {
            public int Votes { get; private set; }
            private UnverifiedVotes(int votes)
            {
                Votes = votes;
            }
            public static Result<UnverifiedVotes> Create(int votes)
            {
                if (ValidNumberOfVotes(votes))
                {
                    return new UnverifiedVotes(votes);
                }
                else
                {
                    return new Result<UnverifiedVotes>(new InvalidVotesException(votes));
                }
            }
            private static bool ValidNumberOfVotes(int votes)
            {
                if (votes != 0)
                {
                    return true;
                }
                return false;
            }
        }
        public class VerifiedVotes : IVote
        {
            public int Votes { get; private set; }
            internal VerifiedVotes(int votes)
            {
                Votes = votes;
            }
        }
    }
}
