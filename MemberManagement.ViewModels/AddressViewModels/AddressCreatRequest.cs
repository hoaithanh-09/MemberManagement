using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
    public class AddressCreatRequest
    {
        public string Nationality { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string StayingAddress { get; set; }
        public string Notes { get; set; }
        public string ParentId { get; set; }

        [NotMapped]
        public List<ProvinceJson> ProvinceJsons { get; set; }

        [NotMapped]
        public List<DistrictJon> DistrictJons { get; set; }

        [NotMapped]
        public List<WardJson> WardJsons { get; set; }
       
    }
}
