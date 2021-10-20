using MemberManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
    public class DistrictVM
    {
        public DistrictVM()
        {
            Wards = new HashSet<Ward>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProvinceId { get; set; }


        public virtual ProvinceVM Province { get; set; }

        public virtual ICollection<Ward> Wards { get; set; }
    }
}
