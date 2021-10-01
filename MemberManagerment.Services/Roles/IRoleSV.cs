using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.RoleViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Roles
{
    public interface IRoleSV
    {
        Task<List<RoleVM>> GetAll();
        Task<int> Create(RoleCreateRequest request);
        Task<int> Delete(int id);
        Task<RoleVM> GetById(int id);
        Task<Data.Entities.Roles> Update(int id, RoleEditRequest request);
        Task<PagedResult<RoleVM>> GetPagedResult(GetRolePagingRequest request);
    }
}
