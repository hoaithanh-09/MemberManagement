using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.ContactViewModels;
using MemberManagerment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Contacts
{
    public interface IContactSV
    {
        Task<List<ContactVM>> GetAll();
        Task<string> Create(ContactCreateRequest request);
        Task<int> Delete(string id);
        Task<ContactVM> GetById(string id);
        Task<Contact> Update(string id, ContactEditRequest request);
        Task<PagedResult<ContactVM>> GetPagedResult(GetContactPagingRequest request);
    }
}
