using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.ImageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MenaberManagement.Client.Services
{
    public interface IImageApi
    {
        Task<List<ImageVM>> GetAll();
        
        Task<ImageVM> GetById(int id);

    }
}
