
using MemberManagement.ViewModels.AuthorViewModels;
using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MenaberManagement.Admin.Services
{
    public interface IAuthorApi
    {
        Task<List<AuthorVM>> GetAll();
        Task<PagedResult<AuthorVM>> GetAuthorPaging(GetAuthorPagingRequest request);

        Task<bool> Create(AuthorCreateRequest request);

        Task<bool> Update(int id, AuthorEditRequest request);
        Task<AuthorVM> GetById(int id);
        Task<bool> Delete(int id);
       
    }
}
