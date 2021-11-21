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
            ContactMembers = new HashSet<ContactMembers>();
            MemberUsers = new HashSet<MemberUser>();
            RoleMembers = new HashSet<RoleMember>();
            ActivityMembers = new HashSet<ActivityMember>();
            FundMembers = new HashSet<FundMember>();
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
        public string PersonalTtles { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Word { get; set; }
        public virtual Family Family { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<AddressMember> AddressMembers { get; set; }
        public virtual ICollection<ContactMembers> ContactMembers { get; set; }
        public virtual ICollection<MemberUser> MemberUsers { get; set; }
        public virtual ICollection<RoleMember> RoleMembers { get; set; }
        public virtual ICollection<ActivityMember> ActivityMembers { get; set; }
        public virtual ICollection<FundMember> FundMembers { get; set; }

    }
}