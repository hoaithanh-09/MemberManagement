using MemberManagerment.ViewModels.FamilyViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Families
{
    public interface IFamilySV
    {
        Task<List<FamilyVM>> getAll();

        Task<string> Create(FamilyCreatRequest request);

        Task<string> Delete(string id);

    }
}
