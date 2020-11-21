using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using LanguageExt;
using LanguageExt.Common;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.EF.Models;
using static StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp.InviteTenantAdminResult;
using static LanguageExt.Prelude;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using Access.Primitives.IO.Mocking;
using Access.Primitives.IO.Attributes;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StackUnderflow.Adapters.InviteAdmin
{
    public partial class InviteTenantAdminAdapter : Adapter<InviteTenantAdminCmd, IInviteTenantAdminResult, BackofficeWriteContext>
    {
        private readonly IExecutionContext _ex;

        public InviteTenantAdminAdapter(IExecutionContext ex)
        {
            _ex = ex;
        }

        public override async Task<IInviteTenantAdminResult> Work(InviteTenantAdminCmd Op, BackofficeWriteContext state)
        {
            var wf = from isValid in Op.TryValidate()
                     from user in Op.AdminUser.ToTryAsync()
                     let token = GenerateActivationToken(user)
                     let response = SendInvitationEmail(user.Email, user.DisplayName, token)
                     select (user, token, response);

            return await wf.Match(
                Succ: async r => (await r.response).StatusCode switch
                    {
                        HttpStatusCode.Accepted => new TenantAdminInvited(r.user, r.token),
                        _ => new TenantAdminNotInvited(),
                    },
                Fail: ex => (IInviteTenantAdminResult)new InvalidRequest(ex.ToString()));
        }

        
        private async Task<Response> SendInvitationEmail(string email, string name, string token)
        {
            //var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            //TODO: SHOULD BE FROM CONFIG
            var client = new SendGridClient("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");

            //TODO: SHOULD BE INPUT OR FROM CONFIG
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("daniel.hort@theaccessgroup.com", "Daniel Hort"),
                Subject = "Test email",
                PlainTextContent = $"Test content : {token}",
                HtmlContent = $"<strong>Test content</strong> : {token}"
            };
            msg.AddTo(new EmailAddress(email, name));
            return await _ex.Effect<SendGridEffect, SendGridClient, SendGridMessage, Task<Response>>(SendEmailAsync, client, msg);
        }

        [SideEffect(typeof(SendGridEffect))]
        public async Task<Response> SendEmailAsync(SendGridClient client, SendGridMessage msg)
        {
            var response = await client.SendEmailAsync(msg);
            return response;
        }

        private string GenerateActivationToken(User user)
        {
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "https://www.theaccessgroup.com/";
            var myAudience = user.WorkspaceId.ToString();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public enum SendGridEffect
    {
        ValidResponse,
        InvalidResponse,
        ThrowsException
    }


    // TODO
    class SendgridOptions
    {
        public string APIKey { get; }
        public List<Sender> Senders { get; }
        public Sender this[string nick] => Senders.Find(a => a.Nickname == nick);

        public class Sender
        {
            public string Email { get; }
            public string Name { get; }
            public string Nickname { get; }
        }
    }
}
