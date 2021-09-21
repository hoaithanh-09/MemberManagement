using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.UserViewModels
{
    public class UserUpdateRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
