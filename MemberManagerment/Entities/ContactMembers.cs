using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class ContactMembers
    {
        [Key]
        public int ID { get; set; }
        public int RoleId { get; set; }
        public int MemberId { get; set; }
        public int ContactId { get; set; }

        public virtual Roles Roles { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Member Member { get; set; }
    }
}
