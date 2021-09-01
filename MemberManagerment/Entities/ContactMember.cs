using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class ContactMember
    {
        public string MemberId { get; set; }
        public string ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Member Member { get; set; }
    }
}
