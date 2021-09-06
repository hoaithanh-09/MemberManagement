using MemberManagement.Services.Groups;
using MemberManagement.ViewModels.GroupViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupSV _groupSV;
//dd
        public GroupsController(IGroupSV groupSV)
        {
            _groupSV = groupSV;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var group = await _groupSV.GetAll();
            return Ok(group);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] GroupCreateRequest request)
        {
            var group = await _groupSV.Create(request);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            var group = await _groupSV.Delete(id);
            return Ok();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var group = await _groupSV.GetById(id);
            return Ok(group);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromForm] GroupUpdateRequest request)
        {
            var group = await _groupSV.Update(id,request);
            return Ok();
        }
    }
}
