using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.GroupViewModels
{
    public class GroupCreateRequest
    {
        [Display(Name = "Tên chi hội")]
        public string Name { get; set; }
        [Display(Name = "Khu vực")]
        public string Region { get; set; }
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
        [Display(Name = "Hội trưởng")]
        public int IdMember { get; set; }

    }
}
