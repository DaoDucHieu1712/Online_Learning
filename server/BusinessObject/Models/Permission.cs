using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Accounts = new HashSet<Account>();
        }

        public int PermissionId { get; set; }
        public string? PermissionName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
