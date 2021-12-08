﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagement.Data.Entities
{
    public partial class AppUser : IdentityUser<int>
    {
        public AppUser()
        {

            MemberUsers = new HashSet<MemberUser>();
            Posts = new HashSet<Post>();
        }


        public bool? ActiveAccount { get; set; }
        public string Avatar { get; set; }
        public bool IsDeleted { get; set; } = false;



        public virtual ICollection<MemberUser> MemberUsers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
