using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.ContactViewModels;
using MemberManagement.ViewModels.GroupViewModels;
using MemberManagement.ViewModels.RoleViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
    public class MemberCreatRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập FamilyId")]
        [Display(Name ="Gia đình")]
        public int FamilyId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập GroupId")]
        [Display(Name = "Chi hội")]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [Display(Name = "Họ và Tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [Display(Name = "Ngày tháng năm sinh")]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Ngày gia nhập")]
        public DateTime JoinDate { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chứng minh thư")]
        [Display(Name = "Chứng minh thư")]
        public string Idcard { get; set; }
        [Display(Name = "Ghi chú")]
        public string Notes { get; set; }
        [Display(Name = "Địa chỉ")]
        public int IdAddress { get; set; }

        [Display(Name = "Chức vụ")]
        public int RoleId { get; set; }
        [Display(Name = "Ban Liên lạc")]
        public int ContactId { get; set; }
        [Display(Name = "Chức danh")]
        public string PersonalTtles { get; set; }
        [Display(Name = "Gmail")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Công việc")]
        public string Word { get; set; }

        [NotMapped]
        public List<FamilyVM> familyVMs { get; set; }

        [NotMapped]
        public List<GroupVM> groupVMs { get; set; }

        public List<AddressVM> Address { get; set; }
        public List<RoleVM> Roles { get; set; }

        public List<ContactVM> Contacts { get; set; }
    }
}
