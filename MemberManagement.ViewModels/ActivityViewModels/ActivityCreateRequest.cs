using MemberManagement.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.ActivityViewModels
{
    public class ActivityCreateRequest
    {
        [Display(Name = "Hoạt động")]
        public string Name { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Chi phí")]
        public double? Cost { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Mã hội viên")]
        public int MemberId { get; set; }
        public List<MemberVM> Members { get; set; }
    }
}
