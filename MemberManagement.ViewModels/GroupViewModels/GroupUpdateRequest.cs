using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.GroupViewModels
{
    public class GroupUpdateRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }

    }
}
