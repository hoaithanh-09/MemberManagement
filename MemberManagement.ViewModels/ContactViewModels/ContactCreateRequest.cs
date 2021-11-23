using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.ContactViewModels
{
    public class ContactCreateRequest
    {
        [Display(Name = "Tên liên lạc")]
        public string Name { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Mã liên lạc")]
        public int Id { get; set; }

    }
}
