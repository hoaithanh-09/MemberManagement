using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.RoleAppVM;
using MemberManagement.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.RolesApp
{
    public class RoleAppSV : IRoleAppSV
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAppSV(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleAppVM>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleAppVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return roles;
        }
    }
}
