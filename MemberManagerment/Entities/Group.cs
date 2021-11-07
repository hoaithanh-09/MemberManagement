using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class Group
    {
        public Group()
        {
            Members = new HashSet<Member>();
            FundGroups = new HashSet<FundGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public int? IdMember { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<FundGroup> FundGroups { get; set; }
    }
}
