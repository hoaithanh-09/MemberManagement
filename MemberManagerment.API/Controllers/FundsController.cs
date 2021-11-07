using MemberManagement.Services.Funds;
using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.FundViewModels;
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
    public class FundsController : ControllerBase
    {

        private readonly IFundSV _fundSV;
        public FundsController(IFundSV fundSV)
        {
            _fundSV = fundSV;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] GetFundPagingRequest request)
        {
            var member = await _fundSV.GetPagedResult(request);
            return Ok(member);
        }


        [HttpPost("Create-Activity")]
        public async Task<ActionResult> Create([FromForm] FundCreateRequest request)
        {
            var member = await _fundSV.Create(request);
            return Ok(member.ResultObj);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromRoute] int id)

        {
            var member = await _fundSV.GetById(id);
            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FundEditRequest request)
        {
            try
            {
                var member = await _fundSV.Update(id, request);
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Creat-activityMember")]
        public async Task<ActionResult> AddMember([FromRoute] int activityId, [FromForm] FundMemberCreateRequest request)
        {
            var member = await _fundSV.AddMember(activityId, request);
            return Ok(member);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var group = await _fundSV.Delete(id);
            return Ok(group);
        }
    }
}
