using MemberManagerment.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Hangfire
{
    public interface IMess
    {
       Task Delete(int idRomm);
    }


    public class Mess : IMess
    {
        private readonly MemberManagementContext _context;
        public Mess(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task Delete(int idRoom)
        {
            var message = await _context.Messages
                .Where(m => m.ToRoomId == idRoom)
                .ToListAsync();

            foreach (var m in message)
            {
                _context.Messages.Remove(m);

            }
            await _context.SaveChangesAsync();

        }
    }
}
