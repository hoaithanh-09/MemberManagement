using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.GroupViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.FundViewModels
{
    public class FundCreateRequest
    {
        [Display(Name = "Tên quỹ")]
        public string Name { get; set; }
        [Display(Name = "Tổng quỹ")]
        public double? TotalFund { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
      
    }
}
