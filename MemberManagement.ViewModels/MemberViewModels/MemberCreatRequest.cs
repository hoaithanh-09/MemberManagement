using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
   public class MemberCreatRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập FamilyId")]
        public string FamilyId { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập GroupId")]
        public string GroupId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        public DateTime Birth { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chứng minh thư")]
        public string Idcard { get; set; }
        public string Notes { get; set; }
    }
}
