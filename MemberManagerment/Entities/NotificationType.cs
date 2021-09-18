using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class NotificationType
    {
        public int Id { get; set; }
        public string NotificationDescription { get; set; }
        public string NotificationMessage { get; set; }
    }
}
