﻿using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using GrainInterfaces;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackUnderflow.API.Rest.Controllers
{
    [ApiController]
    [Route("backoffice")]
    public class BackofficeController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        private readonly IClusterClient _client;

        public BackofficeController(IInterpreterAsync interpreter, StackUnderflowContext dbContext, IClusterClient client)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
            _client = client;
        }

        [HttpPost("tenant")]
        public async Task<IActionResult> CreateTenantAsyncAndInviteAdmin([FromBody] CreateTenantCmd createTenantCmd)
        {
            BackofficeWriteContext ctx = new BackofficeWriteContext(new List<Tenant>(), new List<TenantUser>(), new List<User>());
            var dependencies = new BackofficeDependencies();
            dependencies.GenerateInvitationToken = () => Guid.NewGuid().ToString();
            dependencies.SendInvitationEmail = SendEmail;

            var expr = from createTenantResult in BackofficeDomain.CreateTenant(createTenantCmd)
                       let adminUser = createTenantResult.SafeCast<CreateTenantResult.TenantCreated>().Select(p => p.AdminUser)
                       let inviteAdminCmd = new InviteTenantAdminCmd(adminUser)
                       from inviteAdminResult in BackofficeDomain.InviteTenantAdmin(inviteAdminCmd)
                       select new { createTenantResult, inviteAdminResult };

            var r = await _interpreter.Interpret(expr, ctx, dependencies);

            return r.createTenantResult.Match(
                created => (IActionResult)Ok(created.Tenant.TenantId),
                notCreated => BadRequest("Tenant could not be created."),
                invalidRequest => BadRequest("Invalid request."));
        }
        private TryAsync<InvitationAcknowledgement> SendEmail(InvitationLetter letter)
        => async () =>
        {
            var emialSender = _client.GetGrain<IEmailSender>(0);
            await emialSender.SendEmailAsync(letter.Letter);
            return new InvitationAcknowledgement(Guid.NewGuid().ToString());
        };

    }
}
