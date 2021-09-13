using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FamilyViewModels
{
   public class FamilyEditRequest
    {
        public int Number { get; set; }
        public string HousldRepre { get; set; }
        public DateTime YearBirth { get; set; }
        public int MumberMembers { get; set; }
        public string IdMember { get; set; }
        public string PhoneNumber { get; set; }
    }
}
