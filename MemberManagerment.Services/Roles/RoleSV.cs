using MemberManagement.ViewModels.RoleViewModels;
using MemberManagerment.Data.EF;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManaberManagement.Utilities;
using MemberManagement.Data.Entities;

namespace MemberManagement.Services.Roles
{
    public class RoleSV : IRoleSV
    {
        private readonly MemberManagementContext _context;
        public RoleSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<int> Create(RoleCreateRequest request)
        {
           
            var roleAdd = new Roless()
            {
                Name= request.Name,
                Description= request.Description,
                Note= request.Note,
            };
            _context.Roless.Add(roleAdd);
            await _context.SaveChangesAsync();
            return roleAdd.Id;
        }


        public async Task<int> Delete(int id)
        {
           
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
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Note = x.Note,

            }).ToListAsync();

            return role;
        }

        public async Task<RoleVM> GetById(int id)
        {
            
            var role = await _context.Roless.FindAsync(id);
            if (role == null)
                throw new MemberManagementException("Không tìm thấy!");
            var roleVM = new RoleVM()
            {
                Id = id,
                Name = role.Name,
                Description = role.Description,
                Note = role.Note,
            };
            return roleVM;
        }

        public async Task<Data.Entities.Roless> Update(int id, RoleEditRequest request)
        {
            var rold = await _context.Roless.FindAsync(id);
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
