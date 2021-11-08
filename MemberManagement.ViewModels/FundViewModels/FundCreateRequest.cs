using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.GroupViewModels;
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
        public int GroupId { get; set; }
        public List<GroupVM> Groups { get; set; }
        public List<FundMemberVM> FundMembers { get; set; }
    }
}
