using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityMembers = new HashSet<ActivityMember>();
            FundMembers = new HashSet<FundMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Content { get; set; }
        public double? Cost { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ActivityMember> ActivityMembers { get; set; }
        public virtual ICollection<FundMember> FundMembers { get; set; }
    }
}
