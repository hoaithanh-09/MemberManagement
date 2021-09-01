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
        Task<string> Create(RoleCreateRequest request);
        Task<int> Delete(string id);
        Task<RoleVM> GetById(string id);
    }
}
