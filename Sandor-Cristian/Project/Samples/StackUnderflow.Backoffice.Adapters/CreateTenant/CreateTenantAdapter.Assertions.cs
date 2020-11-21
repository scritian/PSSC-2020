using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using Xunit;

namespace StackUnderflow.Backoffice.Adapters.CreateTenant
{
    public partial class CreateTenantAdapter
    {
        public override Task Assertions(object[] path, CreateTenantCmd op, CreateTenantResult.ICreateTenantResult result, BackofficeWriteContext state)
        {
            var withInput = from inputCase in path.OfType<CreateTenantCmdInput>().HeadOrNone()
                            from stateCase in path.OfType<BackofficeWriteContextInput>().HeadOrNone()
                            select AssertionsOnInput(inputCase, stateCase, state, op, result);

            return Task.CompletedTask;
        }

        private Task AssertionsOnInput(CreateTenantCmdInput inputCase, BackofficeWriteContextInput stateCase, BackofficeWriteContext state, CreateTenantCmd op, CreateTenantResult.ICreateTenantResult result)
        {
            var _ = (inputCase, stateCase) switch
            {
                (CreateTenantCmdInput.Valid, BackofficeWriteContextInput.Empty) => PostConditions(op, result, state),
                (CreateTenantCmdInput.Valid, BackofficeWriteContextInput.Nulls) => PostConditions(op, result, state),
                _ => OnInvalidInput(op, result, state)
            };

            return Task.CompletedTask;
        }

        public Task OnInvalidInput(CreateTenantCmd op, CreateTenantResult.ICreateTenantResult result, BackofficeWriteContext state)
        {
            result.Match(created =>
            {
                Assert.True(op.ValidateObject(), "The command is expected to be invalid");
                Assert.True(false, "We shouldn't create a tenant with invalid input");
                return created;
            },
                notCreated =>
                {
                    Assert.True(false, "Received 'NotCreated', expected InvalidRequest");
                    return notCreated;
                }, invalidRequest =>
                {
                    Assert.True(true);
                    Assert.False(op.ValidateObject(), "The command should be invalid");
                    return invalidRequest;
                });

            return Task.CompletedTask;
        }

        public override Task PostConditions(CreateTenantCmd op, CreateTenantResult.ICreateTenantResult result, BackofficeWriteContext state)
        {
            result.Match(created =>
                {
                    Assert.True(true);
                    Assert.True(op.ValidateObject());
                    Assert.Contains(state.Tenants, tenant => tenant.OrganisationId.Equals(op.OrganisationId));
                    return created;
                }, notCreated =>
                {
                    Assert.True(false);
                    Assert.DoesNotContain(state.Tenants, tenant => tenant.OrganisationId.Equals(op.OrganisationId));
                    return notCreated;
                },
                invalidRequest =>
                {
                    Assert.False(op.ValidateObject());
                    Assert.True(false);
                    return invalidRequest;
                });
            return Task.CompletedTask;
        }
    }
}
