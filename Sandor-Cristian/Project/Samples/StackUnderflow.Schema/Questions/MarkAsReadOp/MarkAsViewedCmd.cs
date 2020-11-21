using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.MarkAsReadOp
{
    public class MarkAsViewedCmd
    {
        public MarkAsViewedCmd(int tenantId, Guid userId, int questionId)
        {
            TenantId = tenantId;
            UserId = userId;
            QuestionId = questionId;
        }

        public int TenantId { get; }
        public Guid UserId { get; }
        public int QuestionId { get; }
    }
}
