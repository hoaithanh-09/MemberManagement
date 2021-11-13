using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
    public class ProvinceJson
    {
        public int level1_id { get; set; }
        public string name { get; set;}
        public string type { get; set;}

       public IEnumerable<DistrictJon> level2s { get; set; }

    }
}
