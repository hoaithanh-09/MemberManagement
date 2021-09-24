using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.RoleAppVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
    public interface IRoleAppApiClient
    {
        Task<ApiResult<List<RoleAppVM>>> GetAll();
    }
}
