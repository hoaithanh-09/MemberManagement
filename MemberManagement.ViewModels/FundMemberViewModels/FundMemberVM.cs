using MemberManagement.ViewModels.FundViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundMemberViewModels
{
    public class FundMemberVM
    {
        public FundVM Fund { get; set; }
        public string Action { get; set; }
        public double? Total { get; set; }
    }
}
