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
            var family = query.ToList();
            var listFamilyVM = new List<FamilyVM>();
            foreach (var f in family)
            {
                var fm = new FamilyVM();

                if (f.Id == 0)
                {
                    fm = new FamilyVM()
                    {
                        Id = 0,
                        HousldRepre = "Chưa có trong danh sách",
                    };
                }
                else
                {
                    var chuho = await _context.Members.FirstOrDefaultAsync(x => x.Id == f.IdMember);
                    if (chuho != null)
                    {
                        fm = new FamilyVM()
                        {
                            Id = f.Id,
                            HousldRepre = chuho.Name,
                        };
                    }
                    else
                    {
                        fm = new FamilyVM()
                        {
                            Id = fm.Id,
                        };

                    }
                }
                
               
                listFamilyVM.Add(fm);
            }
          

            return listFamilyVM;
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
                .Take(request.PageSize).ToListAsync();
            var familyVMs= new List<FamilyVM>();

            foreach (var f in data)
            {
                var member = await _context.Members.FirstOrDefaultAsync(x=>x.Id == f.IdMember);
                if(member == null)
                {
                    var family1 = new FamilyVM()
                    {
                        Id = f.Id,
                    };
                    familyVMs.Add(family1);
                }
                else
                {
                    var membes = await _context.Members.Where(x => x.FamilyId == f.Id).ToListAsync(); ;
                    var family2 = new FamilyVM()
                    {
                        Id = f.Id,
                        HousldRepre = member.Name,
                        MumberMembers = membes.Count,
                        PhoneNumber = member.PhoneNumber,
                        YearBirth = member.Birth,
                        IdMember = member.Id
                    };
                    familyVMs.Add(family2);
                }
            }

            var pagedResult = new PagedResult<FamilyVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = familyVMs
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
