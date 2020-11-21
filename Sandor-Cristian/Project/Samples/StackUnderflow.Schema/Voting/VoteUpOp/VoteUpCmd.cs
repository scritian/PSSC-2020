using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Voting.VoteUpOp
{
    public class VoteUpCmd : VoteCmd
    {
        public VoteUpCmd(int questionId) : base(questionId)
        {
        }

        public override VoteType GetVoteType()
        {
            return VoteType.Up;
        }
    }
}
