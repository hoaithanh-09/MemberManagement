﻿using MemberManagerment.Data.EF;
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
                HousldRepre = request.HousldRepre,
                MumberMembers = request.MumberMembers,
                Number = request.Number,
                PhoneNumber = request.PhoneNumber,
                YearBirth = request.YearBirth,
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
                HousldRepre = x.HousldRepre,
                IdMember = x.IdMember,
                MumberMembers = x.MumberMembers,
                Number = x.Number,
                PhoneNumber = x.PhoneNumber,
                YearBirth = x.YearBirth,
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
                HousldRepre = family.HousldRepre,
                IdMember = family.IdMember,
                MumberMembers = family.MumberMembers,
                Number = family.Number,
                PhoneNumber = family.PhoneNumber,
            };
            return familyVm;
        }

        public async Task<PagedResult<FamilyVM>> GetPagedResult(GetFamilyPagingRequest request)
        {
            var query = from f in _context.Families select f;

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.HousldRepre.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.OrderBy(x => x.Number).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new FamilyVM()
                {
                    Id = x.Id,
                    HousldRepre = x.HousldRepre,
                    IdMember = x.IdMember,
                    MumberMembers = x.MumberMembers,
                    Number = x.Number,
                    PhoneNumber = x.PhoneNumber,
                    YearBirth = x.YearBirth,
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

            family.HousldRepre = request.HousldRepre;
            family.IdMember = request.IdMember;
            family.MumberMembers = request.MumberMembers;
            family.Number = request.Number;
            family.PhoneNumber = request.PhoneNumber;
            family.YearBirth = request.YearBirth;

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
