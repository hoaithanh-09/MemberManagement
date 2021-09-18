using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class Contact
    {
        public Contact()
        {
            ContactMembers = new HashSet<ContactMember>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string PersonalTtles { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Word { get; set; }
        public string UserName { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<ContactMember> ContactMembers { get; set; }
    }
}
