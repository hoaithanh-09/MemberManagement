using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.PostViewModels;
using MemberManagement.ViewModels.TopicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.Client.Models
{
    public class PostInTopicVM
    {
        public TopicVM Topics { get; set; }

        public PagedResult<PostVM> Posts { get; set; }
    }
}
