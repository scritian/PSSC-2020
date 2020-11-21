using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Backend.Interfaces.Responses;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;

namespace StackUnderflow.API.Rest.Controllers
{
    [ApiController]
    [Route("backoffice")]
    public class BackofficeController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;

        public BackofficeController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

        [HttpPost("createTenant")]
        public async Task<IActionResult> CreateTenantAsyncAndInviteAdmin([FromBody] CreateTenantCmd createTenantCmd)
        {
            var ctx = await _dbContext.LoadAsync("dbo.BackofficeHttpController", new
            {
                OrganisationId = createTenantCmd.OrganisationId
            }, async reader =>
            {
                var tenants = await reader.ReadAsync<Tenant>();
                var tenantUsers = await reader.ReadAsync<TenantUser>();
                var users = await reader.ReadAsync<User>();

                _dbContext.AttachRange(tenants);
                _dbContext.AttachRange(tenantUsers);
                _dbContext.AttachRange(users);
                return new BackofficeWriteContext(
                    new EFList<Tenant>(_dbContext.Tenant),
                    new EFList<TenantUser>(_dbContext.TenantUser),
                    new EFList<User>(_dbContext.User));
            });

            var expr = from createResult in BackofficeDomain.CreateTenant(createTenantCmd.OrganisationId,
                                createTenantCmd.TenantName, createTenantCmd.Description, createTenantCmd.AdminEmail, createTenantCmd.AdminName, createTenantCmd.UserId)
                       let adminUser = createResult.SafeCast<CreateTenantResult.TenantCreated>().Select(p => p.User)
                       from u in BackofficeDomain.InviteTenantAdmin(adminUser)
                       select new { createResult, u };

            var r = await _interpreter.Interpret(expr, ctx);

            await _dbContext.SaveChangesAsync();

            return r.createResult.Match(
                created => (IActionResult)Ok(new CreateTenantAndAdminResponse(true, created.Tenant.TenantId, created.User.DisplayName)),
                notCreated => BadRequest(new CreateTenantAndAdminResponse(false, 0, string.Empty)),
                invalidRequest => BadRequest(new CreateTenantAndAdminResponse(false, 0, string.Empty)));
        }



    }
}
