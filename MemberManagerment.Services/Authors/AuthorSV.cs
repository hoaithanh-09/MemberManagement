﻿using ManaberManagement.Utilities;
using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.AuthorViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagerment.Data.EF;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Authors
{
    public class AuthorSV:IAuthorSV
    {
        private readonly MemberManagementContext _context;
        public AuthorSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAuthor(AuthorCreateRequest request)
        {
            var author = new Author()
            {
                Id = request.Id,
                Name = request.Name,
            };
            _context.Add(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }
        public async Task<int> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Remove(author);

            }
            return await _context.SaveChangesAsync();
        }
        public async Task<List<AuthorVM>> GetAllAuthors()
        {
            var query = from f in _context.Authors select f;
            var author = await query.Select(x => new AuthorVM()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();

            return author;
        }
        public async Task<AuthorVM> GetAuthorById(int Id)
        {
            var author = await _context.Authors.FindAsync(Id);
            if (author == null)
                throw new MemberManagementException("Không tìm thấy!");
            var authorVM = new AuthorVM()
            {
                Id=author.Id,
                Name = author.Name,
            };
            return authorVM;
        }
        public async Task<PagedResult<AuthorVM>> GetPagedResultAuthor(GetAuthorPagingRequest request)
        {
            var query = from f in _context.Authors select f;

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new AuthorVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            var pagedResult = new PagedResult<AuthorVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }
        public async Task<Author> UpadateAuthor(int id, AuthorEditRequest request)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new MemberManagementException("Không tìm thấy thông tin !");
            }

            author.Name = request.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetAuthorById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy thông tin");
                }
                else
                {
                    throw;
                }
            }
            return author;
        }

    }
}
