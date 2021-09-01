using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            RoleMembers = new HashSet<RoleMember>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RoleMember> RoleMembers { get; set; }
    }
}
