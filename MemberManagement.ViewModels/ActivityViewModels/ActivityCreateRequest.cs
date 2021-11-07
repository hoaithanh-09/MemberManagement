using MemberManagement.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ActivityViewModels
{
    public class ActivityCreateRequest
    {
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Content { get; set; }
        public double? Cost { get; set; }
        public string Description { get; set; }
        public int MemberId { get; set; }
        public List<MemberVM> Members { get; set; }
    }
}
