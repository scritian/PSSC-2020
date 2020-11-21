using Access.Primitives.Extensions.ObjectExtensions;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace StackUnderflow.Adapters.InviteAdmin
{
    public partial class InviteTenantAdminAdapter
    {
        public override Task Assertions(object[] path, InviteTenantAdminCmd cmd, InviteTenantAdminResult.IInviteTenantAdminResult result, BackofficeWriteContext state)
        {
            var withInput = from inputCase in path.OfType<InviteTenantAdminCmdInput>().HeadOrNone()
                            from stateCase in path.OfType<BackofficeWriteContextInput>().HeadOrNone()
                            select AssertionsOnInput(inputCase, stateCase, state, cmd, result);

            return Task.CompletedTask;
        }

        private Task AssertionsOnInput(InviteTenantAdminCmdInput inputCase, BackofficeWriteContextInput stateCase, BackofficeWriteContext state, InviteTenantAdminCmd cmd, InviteTenantAdminResult.IInviteTenantAdminResult result)
        {
            var _ = (inputCase, stateCase) switch
            {
                (InviteTenantAdminCmdInput.Valid, _) => PostConditions(cmd, result, state),
                _ => OnInvalidInput(cmd, result, state)
            };
            return Task.CompletedTask;
        }

        private Task OnInvalidInput(InviteTenantAdminCmd cmd, InviteTenantAdminResult.IInviteTenantAdminResult result, BackofficeWriteContext state)
        {
            result.Match(
                invited =>
                {
                    Assert.True(cmd.ValidateObject(), "The command is expected to be invalid");
                    Assert.True(false, "Somethin went wrong when creating the tenant");
                    return invited;
                },
                notInvited =>
                {
                    Assert.True(false, "Received 'NotInvited', expected InvalidRequest");
                    return notInvited;
                },
                invalidRequest =>
                {
                    Assert.True(true);
                    Assert.False(cmd.ValidateObject(), "The command should be invalid");
                    return invalidRequest;
                }
            );
            return Task.CompletedTask;
        }

        public override Task PostConditions(InviteTenantAdminCmd cmd, InviteTenantAdminResult.IInviteTenantAdminResult result, BackofficeWriteContext state)
        {
            result.Match(
                invited =>
                {
                    Assert.True(true);
                    Assert.True(cmd.ValidateObject());
                    return invited;
                },
                notInvited =>
                {
                    Assert.True(false);
                    return notInvited;
                },
                invalidRequest =>
                {
                    Assert.True(false);
                    Assert.False(cmd.ValidateObject());
                    return invalidRequest;
                }
            );
            return Task.CompletedTask;
        }
    }
}
