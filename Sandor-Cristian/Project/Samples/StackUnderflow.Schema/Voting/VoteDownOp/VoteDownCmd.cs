using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Voting.VoteDownOp
{
    public class VoteDownCmd : VoteCmd
    {
        public VoteDownCmd(int questionId) : base(questionId)
        {

        }

        public override VoteType GetVoteType()
        {
            return VoteType.Down;
        }
    }
}
