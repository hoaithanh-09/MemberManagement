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
<<<<<<< HEAD
using MemberManagement.ViewModels.AddressMemberViewModels;
=======
using MemberManagement.ViewModels.AddressViewModels;
>>>>>>> 4a479bdac3c55e2400cf0b75fd1301913b4afb10

namespace MemberManagement.Services.Members
{
    public class MemberSV : IMemberSV
    {
        private readonly MemberManagementContext _context;
        public MemberSV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<string> AddAddress(string memberId, AddressMemberCreateRequest request)
        {

            if (string.IsNullOrEmpty(request.IdAddress) || string.IsNullOrEmpty(request.IdAddress))
            {
                throw new MemberManagementException("chưa nhập địa chỉ");
            }

            var address = await _context.Addresses.FindAsync(request.IdAddress);

            if(address==null)
            {
                throw new MemberManagementException("địa chỉ không hợp lệ");
            }

            var addressMember = new AddressMember()
            {
                MemberId = request.IdMember,
                AddressId = address.Id,
            };

            _context.AddressMembers.Add(addressMember);
            await _context.SaveChangesAsync();
            return address.Id;
        }

        public async Task<string> Create(MemberCreatRequest request)
        {
            var address =  _context.Addresses;
            var Addresses = new List<AddressMember>();
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
                        join f in _context.Families on m.FamilyId equals f.Id
                        join g in _context.Groups on m.GroupId equals g.Id
                        select new { m, f,g };

            if (!string.IsNullOrEmpty(request.KeyWord))
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

        public async Task<MemberVM> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("Không tim thấy id");
            var member = await _context.Members.FindAsync(id);
            if (member == null)
                throw new MemberManagementException("Không tìm thấy gia đình");
            var memberVN = new MemberVM()
            {
                Name = member.Name,
                Birth = member.Birth,
                Gender = member.Gender,
                JoinDate = member.JoinDate,
                Idcard = member.Idcard,
                Notes = member.Notes,
        };
            return memberVN;
        }

        public async Task<Member> Update(string id, MemberEditRequest request)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                throw new MemberManagementException("Không tìm thấy địa chỉ");
            }
            member.Name = request.Name;
            member.Birth = request.Birth;
            member.Gender = request.Gender;
            member.JoinDate = request.JoinDate;
            member.Idcard = request.Idcard;
            member.Notes = request.Notes;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy địa chỉ");
                }
                else
                {
                    throw;
                }
            }
            return member;
        }

   
        
    }
}
