using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FamilyViewModels
{
    public class FamilyAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Families { get; set; } = new List<SelectItem>();
    }
}
