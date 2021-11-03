using MemberManagement.ViewModels.ImageInPostViewModels;
using MemberManagement.ViewModels.PostViewModels;
using MemberManagement.ViewModels.TopicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.Client.Models
{
    public class PostDetailViewModel
    {
        public TopicVM Topic { get; set; }

        public PostVM Post { get; set; }

        public List<PostVM> RelatedPosts { get; set; }

        public List<ImageInPostVM> PostImages { get; set; }
    }
}
