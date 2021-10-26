﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.ImageViewModels
{
    public class ImageEditRequest
    {
        public string ImagePath { get; set; }
        public DateTime? DateCreated { get; set; }
        public long? FileSize { get; set; }
    } 
}
