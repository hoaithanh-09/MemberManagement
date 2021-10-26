﻿
using MemberManagement.ViewModels.PostInTopicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.TopicViewModels
{
    public class TopicVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }
        public PostInTopicVM PostInTopics { get; set; }
    }
}
