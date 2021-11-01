using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class ActivityMember
    {
        public int MemberId { get; set; }
        public int ActivityId { get; set; }

        public virtual Member Activity { get; set; }
        public virtual Activity Member { get; set; }
    }
}
