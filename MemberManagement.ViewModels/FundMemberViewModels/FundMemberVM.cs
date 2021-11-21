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
        public double Total { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
