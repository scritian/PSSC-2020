using EarlyPay.Primitives.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace StackUnderflow.Domain.Schema.Backoffice.CreateQuestionOp
{
    public struct CreateQuestionCmd
    {
        [Required]
        public int TenantId { get; }
        [Required]
        public string Title { get; }
        public string Body { get; }
        [GuidNotEmpty]
        public Guid UserId { get; }

        public CreateQuestionCmd(int tenantId, string title, string body, Guid userId)
        {
            TenantId = tenantId;
            Title = title;
            Body = body;
            UserId = userId;
        }
    }
}
