using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class FundMember
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Action { get; set; }
        public double? Total { get; set; }
        public int MemberId { get; set; }
        public int FundId { get; set; }

        public virtual Fund Fund { get; set; }
        public virtual Activity Member { get; set; }
    }
}
