using MemberManagement.ViewModels.AddressMemberViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using MemberManagement.ViewModels.RoleMemberViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
   public class MemberVM
    {
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
        public AddressMemberVM AddressMembers { get; set; }
        public ContactMemberVM ContactMembers { get; set; }
        public RoleMemberVM RoleMembers { get; set; }
        public int Id { get; set; }

        public List<SelectListItem> ListOfFamily { get; set; }
    }
}
