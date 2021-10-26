
using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.AuthorViewModels;
using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Authors
{
    public interface IAuthorSV
    {
        //Author
        Task<int> CreateAuthor(AuthorCreateRequest request);
        Task<int> DeleteAuthor(int id);
        Task<Author> UpadateAuthor(int id, AuthorEditRequest request);
        Task<AuthorVM> GetAuthorById(int id);
        Task<List<AuthorVM>> GetAllAuthors();
        Task<PagedResult<AuthorVM>> GetPagedResultAuthor(GetAuthorPagingRequest request);
    }
}
