﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.RoleViewModels
{
    public class RoleCreateRequest
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public string TypeRole { get; set; }
    }
}
