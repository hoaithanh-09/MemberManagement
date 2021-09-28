using MemberManagement.Services.Groups;
using MemberManagement.ViewModels.GroupViewModels;
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
    public class GroupsController : ControllerBase
    {
        private readonly IGroupSV _groupSV;
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

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaing([FromQuery] GetGroupPagingRequest request)
        {
            var family = await _groupSV.GetPagedResult(request);
            return Ok(family);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] GroupCreateRequest request)
        {
            var group = await _groupSV.Create(request);
            return Ok(group);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var group = await _groupSV.Delete(id);
            return Ok(group);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupSV.GetById(id);
            return Ok(group);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GroupEditRequest request)
        {
            try
            {
                var member = await _groupSV.Update(id, request);
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
