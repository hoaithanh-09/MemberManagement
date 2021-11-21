using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundMemberViewModels
{
    public class FundMemberCreateRequest
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public int MemberId { get; set; }
        public int FundId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
