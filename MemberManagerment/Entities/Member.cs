using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class Member
    {
        public Member()
        {
            AddressMembers = new HashSet<AddressMember>();
            ContactMembers = new HashSet<ContactMember>();
            Images = new HashSet<Image>();
            RoleMembers = new HashSet<RoleMember>();
        }

        public string Id { get; set; }
        public string FamilyId { get; set; }
        public string GroupId { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public string ImageId { get; set; }
        public string Idcard { get; set; }
        public string Notes { get; set; }

        public virtual Family Family { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<AddressMember> AddressMembers { get; set; }
        public virtual ICollection<ContactMember> ContactMembers { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<RoleMember> RoleMembers { get; set; }
    }
}
