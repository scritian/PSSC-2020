using StackUnderflow.EF.Models;
using System.Collections.Generic;

namespace StackUnderflow.Domain.Core.Contexts
{
    public class BackofficeReadContext
    {
        public IEnumerable<Tenant> Tenants { get; }
        public IEnumerable<User> Users { get; }

        public BackofficeReadContext(IEnumerable<Tenant> tenants, IEnumerable<User> users)
        {
            Tenants = tenants;
            Users = users;
        }
    }
}
