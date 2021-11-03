using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MemberManagerment.ViewModels.FamilyViewModels;
using ManaberManagement.Utilities;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagement.Data.Entities;

namespace MemberManagement.Services.Families
{
    public class FamilySV : IFamilySV
    {

        private readonly MemberManagementContext _context;
        public FamilySV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<int> Create(FamilyCreatRequest request)
        {
            var family = await _context.Families.FirstOrDefaultAsync(x => x.IdMember == request.IdMember);
            if (family != null)
            {
                throw new MemberManagementException("Lỗi khi tạo");
            }

            var familyAdd = new Family()
            {
                IdMember = request.IdMember,
            };
            _context.Add(familyAdd);
            _context.SaveChanges();
            return familyAdd.Id;
        }

        public async Task<int> Delete(int id)
        {

            var family = await _context.Families.FindAsync(id);

            if (family != null)
            {
                _context.Remove(family);

            }
            return await _context.SaveChangesAsync(); ;
        }

        public async Task<List<FamilyVM>> getAll()
        {
            var query = from f in _context.Families select f;
            var family = await query.Select(x => new FamilyVM()
            {
                Id = x.Id,
               
            }).ToListAsync();

            return family;
        }

        public async Task<FamilyVM> GetById(int id)
        {

            var family = await _context.Families.FindAsync(id);
            if (family == null)
                throw new MemberManagementException("Không tìm thấy gia đình");
            var familyVm = new FamilyVM()
            {
                IdMember = family.IdMember,
            };
            return familyVm;
        }

        public async Task<PagedResult<FamilyVM>> GetPagedResult(GetFamilyPagingRequest request)
        {
            var query = from f in _context.Families select f;

            

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new FamilyVM()
                {
                    Id = x.Id,
                    IdMember = x.IdMember,
                }).ToListAsync();

            var pagedResult = new PagedResult<FamilyVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<Family> Update(int id, FamilyEditRequest request)
        {
            var family = await _context.Families.FindAsync(id);

            if (family == null)
            {
                throw new MemberManagementException("Không tìm thấy hộ gia đình!");
            }

            family.IdMember = request.IdMember;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy hộ gia đình");
                }
                else
                {
                    throw;
                }
            }
            return family;
        }
    }

}
