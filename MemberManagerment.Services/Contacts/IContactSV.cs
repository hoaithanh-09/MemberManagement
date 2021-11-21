using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.ContactViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Contacts
{
    public interface IContactSV
    {
        Task<List<ContactVM>> GetAll();
        Task<int> Create(ContactCreateRequest request);
        Task<int> Delete(int id);
        Task<ContactVM> GetById(int id);
        Task<Contact> Update(int id, ContactEditRequest request);
        Task<PagedResult<ContactVM>> GetPagedResult(GetContactPagingRequest request);
        Task<PagedResult<ExMembers>> ListMember(int idContract, GetContactPagingRequest request);
        Task<bool> AddMember(int idContract, ContactMemberCreateRequest idMember1);
        Task<bool> RomoveMember(int idContract, int idMember);
    }
}
