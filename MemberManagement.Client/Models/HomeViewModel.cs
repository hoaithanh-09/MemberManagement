using MemberManagement.ViewModels.ImageViewModels;
using MemberManagement.ViewModels.PostViewModels;
using MemberManagement.ViewModels.TopicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.Client.Models
{
    public class HomeViewModel
    {
        public List<PostVM> Posts { get; set; }
        public List<TopicVM> Topics { get; set; }
        public List<ImageVM> Images { get; set; }
    }
}
