using EarlyPay.Primitives.ValidationAttributes;
using LanguageExt;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Schema.Backoffice.InviteUserOp
{
    public struct InviteUserCmd
    {
        public Guid OrganisationId { get;  }
        public Guid UserId { get;  }
        public string UserName { get;  }
        public string UserEmail { get;  }


        public InviteUserCmd(Guid organisationId, Guid userId, string userName, string userEmail)
        {
            OrganisationId = organisationId;
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
        }
    }
}
