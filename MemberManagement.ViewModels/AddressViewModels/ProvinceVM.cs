using MemberManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
  public  class ProvinceVM
    {
        public ProvinceVM()
        {
            Districts = new List<District>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
