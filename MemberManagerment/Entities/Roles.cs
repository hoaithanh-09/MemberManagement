using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            RoleMembers = new HashSet<RoleMember>();
            ContactMembers = new HashSet<ContactMembers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }

        public string TypeRole { get; set; }

        public virtual ICollection<RoleMember> RoleMembers { get; set; }
        public virtual ICollection<ContactMembers> ContactMembers { get; set; }
    }
}
