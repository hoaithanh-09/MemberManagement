using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MemberManagerment.ViewModels.FamilyViewModels;
using MemberManagerment.Data.Entities;

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
<<<<<<< HEAD
        }
        public async Task<List<FamilyVM>> getAll()
        {
            var query =  from f in _context.Families select f;
=======
                }
        public async Task<List<FamilyVM>> getAll()
            {
              var query =  from f in _context.Families select f;
>>>>>>> 2652236bafecbe3bfa6c7e9d59769d0a8833df17
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
    }
}
