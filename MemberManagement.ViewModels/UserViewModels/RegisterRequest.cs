using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.UserViewModels
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MemberId { get; set; }
    }
}
