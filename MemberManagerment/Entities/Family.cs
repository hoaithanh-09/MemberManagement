using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class Family
    {
        public Family()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string IdMember { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
