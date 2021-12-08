using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
    public class MemberEditRequest
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public string Idcard { get; set; }
        public string Notes { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string PersonalTtles { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Word { get; set; }
        public string Addres { get; set; }
    }
}
