using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StackUnderflow.Domain.Schema.Voting
{
    public abstract class VoteCmd
    {

        public enum VoteType
        {
            None = 0,
            Up = 1,
            Down = 2,
            Cancel = 3
        }


        public int QuestionId { get; }
        public abstract VoteType GetVoteType();

        public VoteCmd(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
