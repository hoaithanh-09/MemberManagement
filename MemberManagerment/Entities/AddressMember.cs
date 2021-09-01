using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class AddressMember
    {
        public string MemberId { get; set; }
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Member Member { get; set; }
    }
}
