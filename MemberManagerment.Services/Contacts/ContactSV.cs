using MemberManagement.ViewModels.ContactViewModels;
using MemberManagerment.Data.EF;
using MemberManagerment.Data.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManaberManagement.Utilities;

namespace MemberManagement.Services.Contacts
{
    public class ContactSV : IContactSV
    {
        private readonly MemberManagementContext _context;
        public ContactSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<string> Create(ContactCreateRequest request)
        {
            var contact = await _context.Contacts.FindAsync(request.UserName);
            if(contact!=null)
            {
                //
            }
            var contactAdd = new Contact()
            {
                Id = DateTime.Now.ToString(),
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
      

        public async Task<int> Delete(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new MemberManagementException("Không tồn tại!");
            }
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

        public async Task<ContactVM> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("Không tồn tại!");
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
    }
}
