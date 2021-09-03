using MemberManagement.Services.Contacts;
using MemberManagement.ViewModels.ContactViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactSV _contactSV;
        //dd
        public ContactsController(IContactSV contactSV)
        {
            _contactSV = contactSV;
        }
        [HttpGet("GetALl")]
        public async Task<IActionResult> GetAll()
        {
            var contact = await _contactSV.GetAll();
            return Ok(contact);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] ContactCreateRequest request)
        {
            var contact = await _contactSV.Create(request);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            var contact = await _contactSV.Delete(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var contact = await _contactSV.GetById(id);
            return Ok(contact);
        }
    }
}
