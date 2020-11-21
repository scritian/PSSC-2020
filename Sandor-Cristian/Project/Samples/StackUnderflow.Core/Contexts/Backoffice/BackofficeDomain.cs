using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice.InviteUserOp;
using StackUnderflow.Domain.Schema.Backoffice.SetPermissionsOp;
using StackUnderflow.EF.Models;
using static PortExt;
using static StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp.CreateTenantResult;
using static StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp.InviteTenantAdminResult;
using static StackUnderflow.Domain.Schema.Backoffice.InviteUserOp.InviteUserResult;

namespace StackUnderflow.Domain.Core
{
    public static class BackofficeDomain
    {
        public static Port<ICreateTenantResult> CreateTenant(Guid organisationId, string tenantName, string description, string adminEmail, string adminName, Guid userId) =>
            NewPort<CreateTenantCmd, ICreateTenantResult>(new CreateTenantCmd(organisationId, tenantName, description, adminEmail, adminName, userId));

        public static Port<IInviteTenantAdminResult> InviteTenantAdmin(Option<User> adminUser) =>
            NewPort<InviteTenantAdminCmd, IInviteTenantAdminResult>(new InviteTenantAdminCmd(adminUser));

        public static Port<IInviteUserResult> InviteUser(Guid organisationId, Guid userId, string userName, string userEmail) =>
            NewPort<InviteUserCmd, IInviteUserResult>(new InviteUserCmd(organisationId, userId, userName, userEmail));

        public static Port<SetPermissionResult> SetPermissions(Option<Guid> userId, int level) =>
            NewPort<SetPermissionCmd, SetPermissionResult>(new SetPermissionCmd(userId, level));
    }
}

