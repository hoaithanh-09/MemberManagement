using MemberManagement.ViewModels.AddressViewModels;
using System.Collections.Generic;

namespace MenaberManagement.Admin.Models
{
    public class Tinh
    {
      // public List<ProvinceJson> Data { get; set; }
        //public List<ProvinceJson> Files { set; get; }
        public Dictionary<string, ProvinceJson> Data { get; set; }
    }
}
