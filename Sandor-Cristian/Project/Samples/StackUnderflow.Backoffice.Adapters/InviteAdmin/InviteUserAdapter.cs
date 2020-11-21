using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using LanguageExt;
using LanguageExt.Common;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.InviteUserOp;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Backoffice.InviteUserOp.InviteUserResult;

namespace StackUnderflow.Backoffice.Adapters
{
    public class InviteUserAdapter : Adapter<InviteUserCmd, IInviteUserResult, BackofficeWriteContext>
    {

        public override Task PostConditions(InviteUserCmd cmd, IInviteUserResult result, BackofficeWriteContext state)
        {
            return Task.CompletedTask;
        }

        public override async Task<IInviteUserResult> Work(InviteUserCmd Op, BackofficeWriteContext state)
        {
            var wf = from isValid in Op.TryValidate()
                     let inviteResult = InviteAdmin(Op, state)
                     select inviteResult;

            return await wf.Match(
                Succ: r => r,
                Fail: ex => new InvalidRequest(ex.ToString()));
        }

        private IInviteUserResult InviteAdmin(InviteUserCmd Op, BackofficeWriteContext state)
        {

            // todo - make idempotent

            var user = new User()
            {
                UserId = Op.UserId,
                Name = Op.UserName,
                Email = Op.UserEmail,
                DisplayName = Op.UserName,
                WorkspaceId = Op.UserId
            };

            state.TenantUsers.Add(new TenantUser()
            {
                TenantId = state.Tenants.First(t => t.OrganisationId == Op.OrganisationId).TenantId,
                User = user
            });

            return new UserInvited(user, "dummy-activation-code");
        }
    }
}
