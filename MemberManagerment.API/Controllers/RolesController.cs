using MemberManagement.Services.Roles;
using MemberManagement.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var role = await _roleSV.GetAll();
            return Ok(role);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaing([FromQuery] GetRolePagingRequest request)
        {
            var family = await _roleSV.GetPagedResult(request);
            return Ok(family);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] RoleCreateRequest request)
        {
            var role = await _roleSV.Create(request);
            return Ok(role);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _roleSV.Delete(id);
            return Ok(role);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleSV.GetById(id);
            return Ok(role);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RoleEditRequest request)
        {
            try
            {
                var member = await _roleSV.Update(id, request);
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
    