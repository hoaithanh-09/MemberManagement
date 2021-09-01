using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class Group
    {
        public Group()
        {
            Members = new HashSet<Member>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string IdMember { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
