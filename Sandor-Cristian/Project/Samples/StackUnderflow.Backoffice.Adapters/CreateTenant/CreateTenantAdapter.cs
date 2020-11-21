using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO.Attributes;
using Access.Primitives.IO.Mocking;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.EF.Models;
using Xunit;
using static StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp.CreateTenantResult;

namespace StackUnderflow.Backoffice.Adapters.CreateTenant
{
    public partial class CreateTenantAdapter : Adapter<CreateTenantCmd, ICreateTenantResult, BackofficeWriteContext>
    {
        private readonly IExecutionContext _ex;

        public CreateTenantAdapter(IExecutionContext ex)
        {
            _ex = ex;
        }

        public override async Task<ICreateTenantResult> Work(CreateTenantCmd Op, BackofficeWriteContext state)
        {
            var workflow = from valid in Op.TryValidate()
                           let t = AddTenantIfMissing(state, CreateTenantFromCommand(Op))
                           select t;


            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new InvalidRequest(ex.ToString()));

            return result;
        }
       
        public ICreateTenantResult AddTenantIfMissing(BackofficeWriteContext state, Tenant tenant)
        {
            if (state.Tenants.Any(p => p.Name.Equals(tenant.Name)))
                return new TenantNotCreated();

            if (state.Tenants.All(p => p.TenantId != tenant.TenantId))
                state.Tenants.Add(tenant);
            return new TenantCreated(tenant, tenant.TenantUser.Single().User);
        }

        private Tenant CreateTenantFromCommand(CreateTenantCmd cmd)
        {
            var tenant = new Tenant()
            {
                Description = cmd.Description,
                Name = cmd.TenantName,
                OrganisationId = cmd.OrganisationId,
            };
            tenant.TenantUser.Add(new TenantUser()
            {
                User = new User()
                {
                    UserId = cmd.UserId,
                    Name = cmd.AdminName,
                    Email = cmd.AdminEmail,
                    DisplayName = cmd.AdminName,
                    WorkspaceId = cmd.UserId
                }
            });
            return tenant;
        }
    }
}
