using MemberManagement.ViewModels.AddressViewModels;
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
        public int FamilyId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập GroupId")]
        public int GroupId { get; set; }
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

        public int IdAddress { get; set; }
        public int RoleId { get; set; }
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string PersonalTtles { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Word { get; set; }
        public string UserName { get; set; }

        [NotMapped]
        public List<FamilyVM> familyVMs { get; set; }

        [NotMapped]
        public List<GroupVM> groupVMs { get; set; }

        public List<AddressVM> Address { get; set; }
        public List<RoleVM> Roles { get; set; }
    }
}
