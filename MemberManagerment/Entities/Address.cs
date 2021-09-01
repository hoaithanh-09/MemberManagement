using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            AddressMembers = new HashSet<AddressMember>();
        }

        public string Id { get; set; }
        public string Nationality { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string StayingAddress { get; set; }
        public string Notes { get; set; }
        public string ParentId { get; set; }

        public virtual ICollection<AddressMember> AddressMembers { get; set; }
    }
}
