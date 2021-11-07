using MemberManagement.Services.Activities;
using MemberManagement.ViewModels.ActivityMemberViewModels;
using MemberManagement.ViewModels.ActivityViewModels;
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

    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitySV _activitySV;
        public ActivitiesController(IActivitySV activitySV)
        {
            _activitySV = activitySV;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var family = await _activitySV.GetAll();
            return Ok(family);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] GetActivityPagingRequest request)
        {
            var member = await _activitySV.GetPagedResult(request);
            return Ok(member);
        }


        [HttpPost("Create-Activity")]
        public async Task<ActionResult> Create([FromForm] ActivityCreateRequest request)
        {
            var member = await _activitySV.Create(request);
            return Ok(member.ResultObj);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromRoute] int id)

        {
            var member = await _activitySV.GetById(id);
            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ActivityEditRequest request)
        {
            try
            {
                var member = await _activitySV.Update(id, request);
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Creat-activityMember")]
        public async Task<ActionResult> AddMember([FromRoute] int activityId, [FromForm] ActivityMemberCreateRequest request)
        {
            var member = await _activitySV.AddMember(activityId, request);
            return Ok(member);
        }

       

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var group = await _activitySV.Delete(id);
            return Ok(group);
        }
    }
}
