using MemberManagerment.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Data.Entities
{
    public partial class AppUser : IdentityUser
    {
        public string MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
