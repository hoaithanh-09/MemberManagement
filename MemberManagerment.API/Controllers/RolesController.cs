using MemberManagement.Services.Roles;
using MemberManagement.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleSV _roleSV;
        //dd
        public RolesController(IRoleSV roleSV)
        {
            _roleSV = roleSV;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var role = await _roleSV.GetAll();
            return Ok(role);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RoleCreateRequest request)
        {
            var role = await _roleSV.Create(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            var role = await _roleSV.Delete(id);
            return Ok();
        }

        /*[HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var role = await _roleSV.GetById(id);
            return Ok(role);
        }*/
    }
}
