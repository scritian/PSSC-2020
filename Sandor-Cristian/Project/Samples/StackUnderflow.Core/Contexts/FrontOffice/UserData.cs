using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.FrontOffice
{
    public class UserData
    {
        public ICollection<User> Users { get; }

        public UserData(ICollection<User> users)
        {
            this.Users = users;
        }
    }
}
