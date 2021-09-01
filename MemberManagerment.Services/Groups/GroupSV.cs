using MemberManagement.ViewModels.GroupViewModels;
using MemberManagerment.Data.EF;
using MemberManagerment.Data.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                Id = DateTime.Now.ToString(),
                Name = request.Name,
                Region = request.Region,
                Description = request.Description,
                IdMember = request.IdMember
            };
            _context.Add(groupAdd);
            _context.SaveChanges();
            return groupAdd.Id;
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
    }
}
