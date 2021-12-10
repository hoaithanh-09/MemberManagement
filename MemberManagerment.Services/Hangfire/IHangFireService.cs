using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Hangfire
{
    public interface IHangFireService
    {
        void StartBackgroundService();
        Task DeleteMessSession();
    }

    public class HangFireService : IHangFireService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IMess _mess;

        public HangFireService(IRecurringJobManager recurringJobManager, IMess mess)
        {
            _recurringJobManager = recurringJobManager;
            _mess = mess;
        }
        public void StartBackgroundService()
        {
            _recurringJobManager.AddOrUpdate(
               "DeleteMessSession",
               () => DeleteMessSession(),
               "30 8 * * *"
           );
        }

        public async Task DeleteMessSession()
        {
            await _mess.Delete(1);
        }
    }
}
