using MemberManagement.ViewModels.MemberViewModels;
using MemberManagement.ViewModels.RoleViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ContractMemberViewModels
{
    public class ContactMemberCreateRequest
    {
        public int MemberId { get; set; }
        public int RoleId { get; set; }
        public List<MemberVM> Members { get; set; }

        public List<RoleVM> Roles { get; set; }
    }
}
