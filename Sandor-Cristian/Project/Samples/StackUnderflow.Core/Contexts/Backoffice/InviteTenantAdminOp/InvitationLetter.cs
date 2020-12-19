using System;

namespace StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp
{
    public class InvitationLetter
    {
        public string Email { get; private set; }

        public string Letter { get; private set; }
        public Uri InvitationLink { get; private set; }

        public InvitationLetter(string email, string letter, Uri link)
        {
            Email = email;
            Letter = letter;
            InvitationLink = link;
        }
    }
}
