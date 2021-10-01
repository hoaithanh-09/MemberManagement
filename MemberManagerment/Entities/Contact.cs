﻿using System;
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
        public string Name { get; set; }

        public string Description { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ContactMember> ContactMembers { get; set; }
    }
}
