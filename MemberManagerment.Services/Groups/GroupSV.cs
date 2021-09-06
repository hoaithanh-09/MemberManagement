using MemberManagement.ViewModels.GroupViewModels;
using MemberManagerment.Data.EF;
using MemberManagerment.Data.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManaberManagement.Utilities;

namespace MemberManagement.Services.Groups
{
    public class GroupSV : IGroupSV
    {
        private readonly MemberManagementContext _context;
        public GroupSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<string> Create(GroupCreateRequest request)
        {
            var group = await _context.Groups.FindAsync(request.IdMember);
            if(group!=null)
            {
                //return
            }
            var groupAdd = new Group()
            {
                Id =  request.Name + DateTime.Now.Year.ToString(),
                Name = request.Name,
                Region = request.Region,
                Description = request.Description,
                IdMember = request.IdMember
            };
            _context.Add(groupAdd);
           await _context.SaveChangesAsync();
            return groupAdd.Id;
        }

        public async Task<string> Delete(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return "Chi hoi khong ton tai";
            }
            var group = await _context.Groups.FindAsync(id);
            if(group!=null)
            {
                _context.Remove(group);
                await _context.SaveChangesAsync();
            }
            return "Chi hoi khong ton tai";
        }

        public async Task<List<GroupVM>> GetAll()
        {
            var query = from f in _context.Groups select f;
            var group = await query.Select(x => new GroupVM()
            {
                Name = x.Name,
                Region = x.Region,
                Description = x.Description,
                IdMember = x.IdMember
            }).ToListAsync();

            return group;

        }

        public async Task<GroupVM> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("Không tồn tại!");
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
                throw new MemberManagementException("Không tìm thấy!");
            var groupVM = new GroupVM()
            {
                Name = group.Name,
                Region = group.Region,
                Description = group.Description,
                IdMember = group.IdMember,                
            };
            return groupVM;

        }

        public async Task<int> Update(string id, GroupUpdateRequest request)
        {
            return 1;




        }
    }
}
