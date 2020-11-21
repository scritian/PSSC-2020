using Access.Primitives.IO.Attributes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace StackUnderflow.Adapters.InviteAdmin
{
    public partial class InviteTenantAdminAdapter
    {
        [MockEffect(SendGridEffect.ValidResponse)]
        public async Task<Response> SendEmailAsync_WithValidResponse(SendGridClient client, SendGridMessage msg)
        {
            return new Response(HttpStatusCode.OK, new StringContent(string.Empty), null);
        }


        [MockEffect(SendGridEffect.InvalidResponse)]
        public async Task<Response> SendEmailAsync_WithInvalidResponse(SendGridClient client, SendGridMessage msg)
        {
            return new Response(HttpStatusCode.BadRequest, new StringContent(string.Empty), null);
        }


        [MockEffect(SendGridEffect.ThrowsException)]
        public async Task<Response> SendEmailAsync_ThrowsException(SendGridClient client, SendGridMessage msg)
        {
            throw new ApplicationException("sendgrid client throws an exception");
        }
    }
}
