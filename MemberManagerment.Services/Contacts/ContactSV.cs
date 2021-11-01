﻿using MemberManagement.ViewModels.ContactViewModels;
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
                Name = request.Name,
                Description = request.Description,
                Note = request.Note,
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
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Note = x.Note,
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
                Id = contact.Id,
                Name = contact.Name,
                Description = contact.Description,
                Note = contact.Note,
            };
            return contactVM;
        }

        public async Task<PagedResult<ContactVM>> GetPagedResult(GetContactPagingRequest request)
        {
            var query = from f in _context.Contacts select f;

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ContactVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Note = x.Note,
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

        public async Task<PagedResult<ExMembers>> ListMember(GetContactPagingRequest request)
        {
            var listMember = new List<ExMembers>();
            



            var pagedResult = new PagedResult<ExMembers>
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = listMember.Count,
                Items = listMember,
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

            contact.Name = request.Name;
            contact.Description = request.Description;
            contact.Note = request.Note;
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
