using MemberManagement.ViewModels.FundViewModels;
using MemberManagement.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundMemberViewModels
{
    public class FundMemberVM
    {
        public MemberVM Member { get; set; }
        public string Action { get; set; }
        public double? Total { get; set; }
    }
}
