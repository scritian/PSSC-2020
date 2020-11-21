using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Backoffice.InviteUserOp
{

    [AsChoice]
    public static partial class InviteUserResult
    {
        public interface IInviteUserResult { }

        public class UserInvited : IInviteUserResult
        {
            public User User { get; }
            public string ActivationCode { get; }

            public UserInvited(User user, string activationCode)
            {
                User = user;
                ActivationCode = activationCode;
            }
            ///TODO
        }

        public class TenantAdminNotInvited : IInviteUserResult
        {
            ///TODO
        }

        public class InvalidRequest : IInviteUserResult
        {
            public string Message { get; }

            public InvalidRequest(string message)
            {
                Message = message;
            }

        }
    }
}
