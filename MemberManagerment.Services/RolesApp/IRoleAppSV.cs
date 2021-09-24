using MemberManagement.ViewModels.RoleAppVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.RolesApp
{
    public interface IRoleAppSV
    {
        Task<List<RoleAppVM>> GetAll();
    }
}
