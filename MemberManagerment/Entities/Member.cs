using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class Member
    {
        public Member()
        {
            AddressMembers = new HashSet<AddressMember>();
            ContactMembers = new HashSet<ContactMember>();
            MemberUsers = new HashSet<MemberUser>();
            RoleMembers = new HashSet<RoleMember>();
        }

        public int Id { get; set; }
        public int FamilyId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public string Idcard { get; set; }
        public string Notes { get; set; }

        public string Nickname { get; set; }
        public string PersonalTtles { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Word { get; set; }

        public virtual Family Family { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<AddressMember> AddressMembers { get; set; }
        public virtual ICollection<ContactMember> ContactMembers { get; set; }
        public virtual ICollection<MemberUser> MemberUsers { get; set; }
        public virtual ICollection<RoleMember> RoleMembers { get; set; }
    }
}
