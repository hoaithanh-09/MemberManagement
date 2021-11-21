using ManaberManagement.Utilities;
using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MemberManagement.Data.Entities;

namespace MemberManagement.Services.Addresses
{
    public class AddressSV : IAddressSV
    {
        private readonly MemberManagementContext _context;
        public AddressSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<int> Create(AddressCreatRequest request)
        {
            var address = new Address()
            {
                Nationality = request.Nationality,
                Province = request.Province,
                Ward = request.Ward,
                StayingAddress = request.StayingAddress,
                District = request.District,
                Notes = request.Notes,
            };
             _context.Add(address);
             await _context.SaveChangesAsync();
            return address.Id;
        }

        public async Task<int> Delete(int id)
        {
           
            var family = await _context.Addresses.FindAsync(id);
            if (family != null)
            {
                _context.Addresses.Remove(family);
            }
            return  _context.SaveChanges();
        }

        public async Task<List<AddressVM>> GetAll()
        {
            var query = await _context.Addresses
                .Select(x => new AddressVM()
                {
                    Id = x.Id,
                    Nationality = x.Nationality,
                    Province = x.Province,
                    Ward = x.Ward,
                    District = x.District,
                    Notes = x.Notes,
                    StayingAddress = x.StayingAddress,
                }).ToListAsync();
            return query;
        }

        public async Task<AddressVM> GetById(int id)
        {
         
            var family = await _context.Addresses.FindAsync(id);
            if (family == null)
                throw new MemberManagementException("Không tìm thấy địa chỉ");
            var familyVm = new AddressVM()
            {
                Id = family.Id,
                Nationality = family.Nationality,
                Province = family.Province,
                Ward = family.Ward,
                District = family.District,
                Notes = family.Notes,
            };
            return familyVm;
        }

        public async Task<PagedResult<AddressVM>> GetPagedResult(GetAddressPagingRequest request)
        {
            var query = from f in _context.Addresses select f;

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Nationality.Contains(request.Keyword) 
                || x.Province.Contains(request.Keyword)
                || x.Ward.Contains(request.Keyword)
                || x.District.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new AddressVM()
                {
                    Id = x.Id,
                    Nationality = x.Nationality,
                    Province = x.Province,
                    Ward = x.Ward,
                    District = x.District,
                    Notes = x.Notes,
                    StayingAddress = x.StayingAddress,
                }).ToListAsync();

            var pagedResult = new PagedResult<AddressVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<List<DistrictVM>> LoadDistrict(int id)
        {
            var query = from f in _context.Districts
                        where f.ProvinceId == id
                        select f;
            var provinces = await query.Select(x => new DistrictVM()
            {
                Id = x.Id,
                Name = x.Name,
                Wards = x.Wards,
            }).ToListAsync();


            return provinces;
        }
     
        public async Task<List<ProvinceVM>> LoadProvince()
        {
          
            var query = from f in _context.Provinces select f;
            var provinces = await query.Select(x => new ProvinceVM()
            {
                Id = x.Id,
                Name = x.Name,
                Districts = x.Districts,
            }).ToListAsync();
            

            return provinces;
        }

        public async Task<List<WardVM>> LoadWard(int id)
        {
            var query = from f in _context.Wards
                        where f.DistrictId == id
                        select f;
            var provinces = await query.Select(x => new WardVM()
            {
                Id = x.Id,
                Name = x.Name,
                
            }).ToListAsync();

            return provinces;
        }

        public Task<string> Test()
        {
            throw new NotImplementedException();
        }

        public async Task<Address> Update(int id, AddressEditRequest request)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                throw new MemberManagementException("Không tìm thấy địa chỉ");
            }
            address.Nationality = request.Nationality;
            address.Province = request.Province;
            address.Ward = request.Ward;
            address.District = request.District;
            address.StayingAddress = request.StayingAddress;
            address.Notes = request.Notes;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                if (GetById(id)==null)
                {
                    throw new MemberManagementException("Không tìm thấy địa chỉ");
                }
                else
                {
                    throw;
                }
            }
            return address;

        }
    }
}
