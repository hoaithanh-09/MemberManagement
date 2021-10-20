using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
   public class WardVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DistrictId { get; set; }

        public virtual DistrictVM District { get; set; }
    }
}
