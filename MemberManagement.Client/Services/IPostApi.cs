using MemberManagement.ViewModels.Common;
using Newspaper.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MenaberManagement.Client.Services
{
    public interface IPostApi
    {
        Task<List<PostVM>> GetAll();
     
        Task<PostVM> GetById(int id);

    }
}
