using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.GroupViewModels
{
    public class GroupVM
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public int? IdMember { get; set; }
        public int Id { get; set; }
    }
}
