using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.RoleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
   public interface IRoleApiClient
    {
        Task<PagedResult<RoleVM>> GetFamilyPaging(GetRolePagingRequest request);

        Task<bool> Create(RoleCreateRequest request);

        Task<bool> Update(int id, RoleEditRequest request);
        Task<RoleVM> GetById(int id);
        Task<bool> Delete(int id);
    }
}
