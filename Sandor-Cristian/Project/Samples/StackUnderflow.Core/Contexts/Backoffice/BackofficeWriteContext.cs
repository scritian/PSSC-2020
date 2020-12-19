using StackUnderflow.EF.Models;
using System.Collections.Generic;

namespace StackUnderflow.Domain.Core.Contexts
{
    public class BackofficeWriteContext
    {
        public ICollection<Tenant> Tenants { get; }
        public ICollection<TenantUser> TenantUsers { get; }
        public ICollection<User> Users { get; }

        public BackofficeWriteContext(ICollection<Tenant> tenants, ICollection<TenantUser> tenantUsers, ICollection<User> users)
        {
            Tenants = tenants ?? new List<Tenant>(0);
            TenantUsers = tenantUsers ?? new List<TenantUser>(0);
            Users = users ?? new List<User>(0);
        }
    }
}
