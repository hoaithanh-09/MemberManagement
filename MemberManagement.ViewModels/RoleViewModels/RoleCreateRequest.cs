using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.RoleViewModels
{
    public class RoleCreateRequest
    {
        [Display(Name = "Chức vụ")]
        public string Name { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Thể loại chức vụ")]
        public string TypeRole { get; set; }
    }
}
