using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.PostInTopicViewModels
{
    public class PostInTopicCreateRequest
    {
        public int TopicId { get; set; }
        public int PostId { get; set; }
    }
}
