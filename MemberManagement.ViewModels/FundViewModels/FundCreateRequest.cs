using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundViewModels
{
    public class FundCreateRequest
    {
        public string Name { get; set; }
        public double? TotalFund { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }
        public int MemberId { get; set; }
        public List<MemberVM> Members { get; set; }
        public List<FundMemberVM> FundMembers { get; set; }
    }
}
