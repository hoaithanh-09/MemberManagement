
using MemberManagement.ViewModels.AuthorViewModels;
using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MenaberManagement.Client.Services
{
    public interface IAuthorApi
    {
        Task<List<AuthorVM>> GetAll();

        Task<AuthorVM> GetById(int id);
    }
}
