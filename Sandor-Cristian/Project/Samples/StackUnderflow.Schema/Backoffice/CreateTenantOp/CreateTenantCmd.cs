using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;

namespace StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp
{
    public enum CreateTenantCmdInput
    {
        Valid,
        EmptyOrgId,
        EmptyName,
        EmptyEmail,
        EmptyUserId
    }

    public class CreateTenantCmdInputGen : InputGenerator<CreateTenantCmd, CreateTenantCmdInput>
    {
        public CreateTenantCmdInputGen()
        {
            mappings.Add(CreateTenantCmdInput.Valid, () => 
                new CreateTenantCmd(Guid.NewGuid(), 
                    $"{Guid.NewGuid()}-tenant-name", 
                    $"{Guid.NewGuid()}-description", 
                    $"{Guid.NewGuid()}@adminemail.tld", 
                    $"{Guid.NewGuid()}-adminname", 
                    Guid.NewGuid()));

            mappings.Add(CreateTenantCmdInput.EmptyEmail, () =>
                new CreateTenantCmd(Guid.NewGuid(),
                    $"{Guid.NewGuid()}-tenant-name",
                    $"{Guid.NewGuid()}-description",
                    null,
                    $"{Guid.NewGuid()}-adminname",
                    Guid.NewGuid()));
            mappings.Add(CreateTenantCmdInput.EmptyName, () =>
                new CreateTenantCmd(Guid.NewGuid(),
                    $"{Guid.NewGuid()}-tenant-name",
                    $"{Guid.NewGuid()}-description",
                    $"{Guid.NewGuid()}@adminemail.tld",
                    "",
                    Guid.NewGuid()));
            mappings.Add(CreateTenantCmdInput.EmptyOrgId, () =>
                new CreateTenantCmd(Guid.Empty,
                    $"{Guid.NewGuid()}-tenant-name",
                    $"{Guid.NewGuid()}-description",
                    $"{Guid.NewGuid()}@adminemail.tld",
                    $"{Guid.NewGuid()}-adminname",
                    Guid.NewGuid()));
            mappings.Add(CreateTenantCmdInput.EmptyUserId, () =>
                new CreateTenantCmd(Guid.NewGuid(),
                    $"{Guid.NewGuid()}-tenant-name",
                    $"{Guid.NewGuid()}-description",
                    $"{Guid.NewGuid()}@adminemail.tld",
                    $"{Guid.NewGuid()}-adminname",
                    Guid.Empty));
        }
    }


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
