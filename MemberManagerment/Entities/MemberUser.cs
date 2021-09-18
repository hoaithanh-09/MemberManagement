using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class MemberUser
    {
        public int MemberId { get; set; }
        public int UserId { get; set; }

        public virtual Member Member { get; set; }
        public virtual AppUser User { get; set; }
    }
}
