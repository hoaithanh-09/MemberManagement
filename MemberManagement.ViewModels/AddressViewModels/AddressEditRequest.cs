using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
    public class AddressEditRequest
    {
        public string Nationality { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string StayingAddress { get; set; }
        public string Notes { get; set; }
        public string ParentId { get; set; }
    }
}
