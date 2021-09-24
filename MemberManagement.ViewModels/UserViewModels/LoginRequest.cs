using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.UserViewModels
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="Nhập tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu")]
        public string Password { get; set; }
    }
}
