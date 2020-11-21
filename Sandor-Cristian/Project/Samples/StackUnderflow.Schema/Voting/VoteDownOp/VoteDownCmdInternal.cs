using StackUnderflow.Domain.Schema.Voting.VoteUpOp;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Voting.VoteDownOp
{
    public class VoteDownCmdInternal : VoteDownCmd
    {

        public VoteDownCmdInternal(int tenantId, Guid userId, int questionId) : base(questionId)
        {
            TenantId = tenantId;
            UserId = userId;
        }

        public int TenantId { get; }
        public Guid UserId { get; }
    }
}
