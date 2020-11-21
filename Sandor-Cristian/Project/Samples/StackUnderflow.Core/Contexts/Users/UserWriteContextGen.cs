using System.Collections.Generic;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.FrontOffice;
using StackUnderflow.EF.Models;

namespace StackUnderflow.Domain.Core.Contexts
{

    public enum UserWriteContextInput
    {
        Empty,
        Nulls
    }

    public class UserWriteContextGen : InputGenerator<UserWriteContext, UserWriteContextInput>
    {
        public UserWriteContextGen()
        {
            mappings.Add(UserWriteContextInput.Empty, () => new UserWriteContext(new List<User>()));
            mappings.Add(UserWriteContextInput.Nulls, () => new UserWriteContext(null));
        }
    }

    public class UserWriteContext
    {
        public ICollection<User> Users { get; }

        public UserWriteContext(ICollection<User> users)
        {
            this.Users = users;
        }
    }
}