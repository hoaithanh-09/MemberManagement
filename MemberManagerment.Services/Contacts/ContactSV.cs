using MemberManagement.ViewModels.ContactViewModels;
using MemberManagerment.Data.EF;

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManaberManagement.Utilities;
using MemberManagement.ViewModels.Common;
using MemberManagement.Data.Entities;

namespace MemberManagement.Services.Contacts
{
    public class ContactSV : IContactSV
    {
        private readonly MemberManagementContext _context;
        public ContactSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ContactCreateRequest request)
        {
           
            var contactAdd = new Contact()
            {
                FullName=request.FullName,
                Nickname=request.Nickname,
                PersonalTtles=request.PersonalTtles,
                Email=request.Email,
                PhoneNumber=request.PhoneNumber,
                Word=request.Word,
                UserName=request.UserName,
                Notes=request.Notes,
            };
            _context.Add(contactAdd);
            await _context.SaveChangesAsync();
            return contactAdd.Id;
        }
      

        public async Task<int> Delete(int id)
        {
           
            var contact = await _context.Contacts.FindAsync(id);
            if(contact!=null)
            {
                _context.Remove(contact);
                
            }
            return await _context.SaveChangesAsync(); 
        }

        public async Task<List<ContactVM>> GetAll()
        {
            var query = from f in _context.Contacts select f;
            var contact = await query.Select(x => new ContactVM()
            {
                FullName = x.FullName,
                Nickname = x.Nickname,
                PersonalTtles = x.PersonalTtles,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Word = x.Word,
                UserName = x.UserName,
                Notes = x.Notes,
            }).ToListAsync();

            return contact;
        }

        public async Task<ContactVM> GetById(int id)
        {
            
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                throw new MemberManagementException("Không tìm thấy!");
            var contactVM = new ContactVM()
            {
                FullName = contact.FullName,
                Nickname = contact.Nickname,
                PersonalTtles = contact.PersonalTtles,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Word = contact.Word,
                UserName = contact.UserName,
                Notes = contact.Notes,
            };
            return contactVM;
        }

        public async Task<PagedResult<ContactVM>> GetPagedResult(GetContactPagingRequest request)
        {
            var query = from f in _context.Contacts select f;

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.FullName.Contains(request.Keyword)
                || x.Email.Contains(request.Keyword)
                || x.Nickname.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ContactVM()
                {
                    FullName = x.FullName,
                    Nickname = x.Nickname,
                    PersonalTtles = x.PersonalTtles,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Word = x.Word,
                    UserName = x.UserName,
                    Notes = x.Notes,
                }).ToListAsync();

            var pagedResult = new PagedResult<ContactVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<Contact> Update(int id, ContactEditRequest request)
        {
            var contact = await _context.Contacts.FindAsync(id);
          
            if (contact == null)
            {
                throw new MemberManagementException("Không tìm thấy thông tin !");
            }
            contact.FullName = request.FullName;
            contact.Nickname = request.Nickname;
            contact.PersonalTtles = request.PersonalTtles;
            contact.Email = request.Email;
            contact.PhoneNumber = request.PhoneNumber;
            contact.Word = request.Word;
            contact.UserName = request.UserName;
            contact.Notes = request.Notes;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy thông tin");
                }
                else
                {
                    throw;
                }
            }
            return contact;
        }
    }
}
