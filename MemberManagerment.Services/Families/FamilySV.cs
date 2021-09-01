﻿using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MemberManagerment.ViewModels.FamilyViewModels;
using MemberManagerment.Data.Entities;
using ManaberManagement.Utilities;

namespace MemberManagement.Services.Families
{
    public class FamilySV : IFamilySV
    {

        private readonly MemberManagementContext _context;
        public FamilySV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<string> Create(FamilyCreatRequest request)
        {
            var family = await _context.Families.FindAsync(request.IdMember);
            if (family != null)
            {
               // tra ra thong bao
            }

            var familyAdd = new Family()
            {
                Id = DateTime.Now.ToString(),
                IdMember =request.IdMember,
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

        public async Task<int> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                 throw new MemberManagementException("Không tìm thấy :" + id);
            var family = await _context.Families.FindAsync(id);

            if (family != null)
            {
              _context.Remove(family);
             
            }

            return await _context.SaveChangesAsync(); ;
        }

        public async Task<List<FamilyVM>> getAll()
            {
              var query =  from f in _context.Families select f;
            var family = await query.Select(x => new FamilyVM()
            {
                HousldRepre = x.HousldRepre,
                IdMember = x.IdMember,
                MumberMembers = x.MumberMembers,
                Number = x.Number,
                PhoneNumber = x.PhoneNumber,
                YearBirth = x.YearBirth,
            }).ToListAsync();

            return family;
        }

        public async Task<FamilyVM> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new  MemberManagementException("Không tim thấy id");
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
    }
}
