using MemberManagement.ViewModels.AddressMemberViewModels;
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

        public virtual AddressMemberVM AddressMembers { get; set; }
    }
}
