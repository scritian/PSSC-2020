using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Voting.CancelVoteOp
{
    public class CancelVoteCmd : VoteCmd
    {
        public CancelVoteCmd(int questionId) : base(questionId)
        {
        }

        public override VoteType GetVoteType()
        {
            return VoteType.Cancel;
        }
    }
}
