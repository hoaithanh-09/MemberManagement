using ManaberManagement.Utilities;
using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagerment.Data.EF;
using MemberManagerment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MemberManagement.Services.Addresses
{
    public class AddressSV : IAddressSV
    {
        private readonly MemberManagementContext _context;
        public AddressSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<string> Create(AddressCreatRequest request)
        {
            var address = new Address()
            {
                Id = request.Province + request.Ward,
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

        public async Task<int> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("Không tìm thấy :" + id);
            var family = await _context.Contacts.FindAsync(id);
            if (family != null)
            {
                _context.Remove(family);
            }
            return  _context.SaveChanges();
        }

        public async Task<AddressVM> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("Không tim thấy id");
            var family = await _context.Addresses.FindAsync(id);
            if (family == null)
                throw new MemberManagementException("Không tìm thấy gia đình");
            var familyVm = new AddressVM()
            {
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
                && x.Province.Contains(request.Keyword) 
                && x.Ward.Contains(request.Keyword) 
                && x.District.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new AddressVM()
                {
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

        public async Task<Address> Update(string id, AddressEditRequest request)
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
