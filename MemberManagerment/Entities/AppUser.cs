using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class AppUser : IdentityUser
    {
        public AppUser()
        {

            MemberUsers = new HashSet<MemberUser>();
            Posts = new HashSet<Post>();
        }


        public bool? ActiveAccount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public byte[] ProfileImage { get; set; }
        public string About { get; set; }


        public virtual ICollection<MemberUser> MemberUsers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }


    }
}
