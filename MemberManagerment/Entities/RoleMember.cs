using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class RoleMember
    {
        public string MemberId { get; set; }
        public string RoleId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Role Role { get; set; }
    }
}
