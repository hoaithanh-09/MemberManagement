using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.UserViewModels
{
    public class UserVM
    {
        public int  Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}
