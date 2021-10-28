using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.TopicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MenaberManagement.Client.Services
{
    public interface ITopicApi
    {

        Task<List<TopicVM>> GetAll();

        Task<TopicVM> GetById(int id);
  
    }
}
