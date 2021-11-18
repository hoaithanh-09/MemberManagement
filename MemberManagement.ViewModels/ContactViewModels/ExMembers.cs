using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ContactViewModels
{
    public class ExMembersViewModel
    {
        public int IdContact { get; set; }
        public List<ExMembers> exMembers { get; set; }

     }
    public class ExMembers
    {
        public string Name { get; set; }
        public string PersonalTitles { get; set; }
        public string Work { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
