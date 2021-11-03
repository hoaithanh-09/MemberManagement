using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundMemberViewModels
{
    public class FundMemberCreateRequest
    {
        public string Action { get; set; }
        public double? Total { get; set; }
        public int MemberId { get; set; }
        public int FundId { get; set; }
    }
}
