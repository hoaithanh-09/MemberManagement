using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ContactViewModels
{
    public class GetContactPagedResult <T> : PagedResult<T> where T : class
    {
        public int IdContact { get; set; }
    }
}
