using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Models
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.Provinces = new List<SelectListItem>();
            this.Districts = new List<SelectListItem>();
            this.Wards = new List<SelectListItem>();
        }

        public List<SelectListItem> Provinces { get; set; }
        public List<SelectListItem> Districts { get; set; }
        public List<SelectListItem> Wards { get; set; }

        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
    }
}
