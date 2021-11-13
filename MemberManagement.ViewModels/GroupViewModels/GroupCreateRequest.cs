﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.GroupViewModels
{
    public class GroupCreateRequest
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public int IdMember { get; set; }

    }
}
