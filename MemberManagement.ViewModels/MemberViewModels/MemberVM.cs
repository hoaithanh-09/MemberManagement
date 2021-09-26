using MemberManagement.ViewModels.AddressMemberViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using MemberManagement.ViewModels.RoleMemberViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
   public class MemberVM
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public string Idcard { get; set; }
        public string Notes { get; set; }

        public AddressMemberVM AddressMembers { get; set; }
        public ContactMemberVM ContactMembers { get; set; }
        public RoleMemberVM RoleMembers { get; set; }
        public object Id { get; set; }
    }
}
