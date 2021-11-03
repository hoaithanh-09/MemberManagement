﻿using MemberManagement.ViewModels.ImageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.PostViewModels
{
    public class PostCreateRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AuthorId { get; set; }
        public string Content { get; set; }
        public int ImageId { get; set; }
        public List<ImageVM> Images { get; set; }

    }
}
