using MemberManagement.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Members
{
   public interface IMemberSV
    {
        Task<List<MemberVM>> GetAll();

      //  Task<string> 
    }
}
