﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.PostViewModels
{
   public class PostVM
    {
        public int UserId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Text { get; set; }
    }
}