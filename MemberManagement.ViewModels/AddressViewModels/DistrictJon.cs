using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
    public class DistrictJon
    {
        public int level2_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public IEnumerable<WardJson> level3s { get; set; }

    }
}
