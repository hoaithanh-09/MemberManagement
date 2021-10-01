using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ContactViewModels
{
    public class ContactCreateRequest
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

    }
}
