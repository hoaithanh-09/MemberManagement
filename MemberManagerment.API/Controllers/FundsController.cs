using MemberManagement.Services.FundGroupSServices;
using MemberManagement.Services.Funds;
using MemberManagement.ViewModels.FundGroupVIewModels;
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
        private readonly IFundMemberService _fundMemberService;
        private readonly IFundGoupService _fundGoupService;
        public FundsController(IFundSV fundSV, IFundMemberService fundMemberService, IFundGoupService fundGoupService)
        {
            _fundSV = fundSV;
            _fundGoupService = fundGoupService;
            _fundMemberService = fundMemberService;

        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] GetFundPagingRequest request)
        {
            var member = await _fundSV.GetPagedResult(request);
            return Ok(member);
        }


       
        [HttpGet("{id}")]
        public async Task<ActionResult> getID(int id)

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

        [HttpPost]
        public async Task<ActionResult> Create( [FromBody] FundCreateRequest request)
        {
            var member = await _fundSV.Create(request);
            return Ok(member);
        }

        [HttpPost("Creatlistmember")]
        public async Task<ActionResult> Creatlistmember(int fundId, [FromBody] MemberManagement.ViewModels.FGViewModels.FundMemberCreateRequest request)
        {
            request.FundId = fundId;
            var member = await _fundMemberService.Create(request);
            return Ok(member);
        }


        [HttpPost("RemoveMember")]
        public async Task<ActionResult> RemoveMember(int id)
        {
            var member = await _fundMemberService.Delete(id);
            return Ok(member);
        }


        [HttpPost("RemoveActiviti")]
        public async Task<ActionResult> RemoveActiviti(int id)
        {
            var member = await _fundGoupService.Delete(id);
            return Ok(member);
        }


        [HttpPost("CreateActivity")]
        public async Task<ActionResult> CreateActivity([FromBody] MemberManagement.ViewModels.FGViewModels.FundGoupCreateRequest request)
        {
            var member = await _fundGoupService.Create(request);
            return Ok(member.ResultObj);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var group = await _fundSV.Delete(id);
            return Ok(group);
        }

        [HttpGet("ListAction")]
        public async Task<IActionResult> ListAction(int fundId, [FromQuery] GetFundPagingRequest request)
        {
            var family = await _fundGoupService.GetPaged(fundId, request);

            return Ok(family);
        }

        [HttpGet("ListMember")]
        public async Task<IActionResult> ListMembers(int fundId, [FromQuery] GetFundPagingRequest request)
        {
            var family = await _fundMemberService.GetPaged(fundId, request);

            return Ok(family);
        }
    }
}
