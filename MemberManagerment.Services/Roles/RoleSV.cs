using MemberManagement.ViewModels.RoleViewModels;
using MemberManagerment.Data.EF;
using MemberManagerment.Data.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManaberManagement.Utilities;

namespace MemberManagement.Services.Roles
{
    public class RoleSV : IRoleSV
    {
        private readonly MemberManagementContext _context;
        public RoleSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<string> Create(RoleCreateRequest request)
        {
            var role = await _context.Roless.FindAsync(request.Name);
            if (role != null)
            {
                //
            }
            var roleAdd = new Role()
            {
                Id = DateTime.Now.Second.ToString(),
                Name=request.Name,
                Description=request.Description,
                Note=request.Note,
            };
            _context.Roless.Add(roleAdd);
            await _context.SaveChangesAsync();
            return roleAdd.Id;
        }


        public async Task<int> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new MemberManagementException("Không tồn tại!");
            }
            var role = await _context.Roless.FindAsync(id);
            if (role != null)
            {
                _context.Remove(role);

            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<RoleVM>> GetAll()
        {
            var query = from f in _context.Roless select f;
            var role = await query.Select(x => new RoleVM()
            {
                Name = x.Name,
                Description = x.Description,
                Note = x.Note,

            }).ToListAsync();

            return role;
        }

        public async Task<RoleVM> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("Không tồn tại!");
            var role = await _context.Roless.FindAsync(id);
            if (role == null)
                throw new MemberManagementException("Không tìm thấy!");
            var roleVM = new RoleVM()
            {
                Name = role.Name,
                Description = role.Description,
                Note = role.Note,
            };
            return roleVM;
        }

        public async Task<Role> Update(string id, RoleEditRequest request)
        {
            var rold = await _context.Roless.FindAsync(id);
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("vui lòng chọn thông tin");
            if (rold == null)
            {
                throw new MemberManagementException("Không tìm thấy vai trò !");
            }
            rold.Name = request.Name;
            rold.Description = request.Description;
            rold.Note = request.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy vai trò");
                }
                else
                {
                    throw;
                }
            }
            return rold;
        }
    }
}
