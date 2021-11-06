using MemberManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ActivityViewModels
{
    public class ActivityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Content { get; set; }
        public double? Cost { get; set; }
        public string Description { get; set; }
        public ActivityMember ActivityMembers { get; set; }
    }
}
