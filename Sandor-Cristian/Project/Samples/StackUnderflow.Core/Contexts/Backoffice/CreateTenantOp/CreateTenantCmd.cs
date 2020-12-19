using EarlyPay.Primitives.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp
{
    public struct CreateTenantCmd
    {
        public CreateTenantCmd(Guid organisationId, string tenantName, string description, string adminEmail, string adminName, Guid userId)
        {
            OrganisationId = organisationId;
            TenantName = tenantName;
            Description = description;
            AdminEmail = adminEmail;
            AdminName = adminName;
            UserId = userId;
        }

        [GuidNotEmpty]
        public Guid OrganisationId { get; set; }

        [Required]
        public string TenantName { get; set; }

        public string Description { get; set; }

        [Required]
        public string AdminEmail { get; set; }
        [Required]
        public string AdminName { get; set; }
        [Required]

        [GuidNotEmpty]
        public Guid UserId { get; set; }
    }
}
