using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class RoleMember
    {
        public int MemberId { get; set; }
        public int RoleId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Roles Role { get; set; }
    }
}
