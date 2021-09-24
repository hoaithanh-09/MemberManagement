using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.UserViewModels
{
    public class RegisterRequest
    {
        [Display(Name ="Tài khoản")]
        public string UserName { get; set; }
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        public string MemberId { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
