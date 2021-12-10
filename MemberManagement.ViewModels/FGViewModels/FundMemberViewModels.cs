using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FGViewModels
{
    public class FundMemberCreateRequest
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public double Total { get; set; }
        public int MemberId { get; set; }
        public int FundId { get; set; }

    }  
    public class FundMemberVM
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public double Total { get; set; }
        public int MemberId { get; set; }
        public int FundId { get; set; }
    }  
    public class FundMemberEditRequest
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public double Total { get; set; }
        public int MemberId { get; set; }
        public int FundId { get; set; }
    }
}
