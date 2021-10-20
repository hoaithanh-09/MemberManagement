using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.ContactViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
    public interface IContactApiClientcs
    {
        Task<PagedResult<ContactVM>> GetFamilyPaging(GetContactPagingRequest request);

        Task<bool> Create(ContactCreateRequest request);

        Task<bool> Update(int id, ContactEditRequest request);
        Task<ContactVM> GetById(int id);
        Task<bool> Delete(int id);

        Task<List<ContactVM>> GetAll();

       
    }
}
