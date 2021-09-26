using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagerment.ViewModels.FamilyViewModels
{
    public class FamilyVM
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string HousldRepre { get; set; }
        public DateTime YearBirth { get; set; }
        public int MumberMembers { get; set; }
        public string IdMember { get; set; }
        public string PhoneNumber { get; set; }
    }
}
