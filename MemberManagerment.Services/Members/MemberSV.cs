using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MemberManagerment.Data.Entities;
using ManaberManagement.Utilities;

namespace MemberManagement.Services.Members
{
    public class MemberSV : IMemberSV
    {
        private readonly MemberManagementContext _context;
        public MemberSV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<string> Create(MemberCreatRequest request)
        {
            var member = await _context.Members.FindAsync(request.Idcard);
            if (member != null)
            {
                throw new MemberManagementException("Hội viên đã tồn tại");
            }

            var family = await _context.Families.FindAsync(request.FamilyId);
            if(family == null)
            {
                throw new MemberManagementException("Gia đình chưa tồn tại");
            }
            var group = await _context.Groups.FindAsync(request.GroupId);
            if (group == null)
            {
                throw new MemberManagementException("Chi hội chưa tồn tại");
            }
            member = new Member()
            {
                Id = request.Name + DateTime.Now.Year.ToString(),
                Name = request.Name,
                Gender = request.Gender,
                Idcard = request.Idcard,
                JoinDate = request.JoinDate,
                Notes = request.Notes,
                Family = family,
                Group = group,
                FamilyId = request.FamilyId,
                GroupId = request.GroupId,
                Birth = request.Birth,
                ImageId = "Sdasdas",
            };
            _context.Add(member);
            await _context.SaveChangesAsync();
            return member.Name;
        }

        public async Task<PagedResult<MemberVM>> GetAllPaging(MemberPaingRequest request)
        {
            var query = from m in _context.Members
                        join f in _context.Families on m.Id equals f.IdMember
                        join g in _context.Groups on m.Id equals g.IdMember
                        select new { m, f,g };

            if (string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.m.Name.Contains(request.KeyWord));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new MemberVM()
                {
                   Name = x.m.Name,
                   Birth = x.m.Birth,
                   Gender = x.m.Gender,
                   Idcard = x.m.Idcard,
                   JoinDate = x.m.JoinDate,
                   Notes = x.m.Notes,
                   GroupName = x.g.Name,
                   
                }).ToListAsync();
            var paging = new PagedResult<MemberVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data,
            };
            return paging;
        }
    }
}
