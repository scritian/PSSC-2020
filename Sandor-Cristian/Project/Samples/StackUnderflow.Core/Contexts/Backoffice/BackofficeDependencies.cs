﻿using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using System;

namespace StackUnderflow.Domain.Schema.Backoffice
{
    public class BackofficeDependencies
    {
        public Func<string> GenerateInvitationToken { get; set; }
        public Func<InvitationLetter, TryAsync<InvitationAcknowledgement>> SendInvitationEmail { get; set; }
    }
}
