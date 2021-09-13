
using MemberManagement.Services.Members;
using MemberManagement.ViewModels.AddressMemberViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagement.ViewModels.RoleMemberViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
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
   
    public class MembersController : ControllerBase
    {
        private readonly IMemberSV _memberSV;
        public MembersController(IMemberSV memberSV)
        {
            _memberSV = memberSV;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]MemberPaingRequest request)
        {
            var member = await _memberSV.GetAllPaging(request);
            return Ok(member.Items);
        }
        [HttpPost("Creat-Member")]
        public async Task<ActionResult> Create([FromForm] MemberCreatRequest request)
        {
            var member = await _memberSV.Create(request);
            return Ok(member);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromRoute] string id)

        {
            var member = await _memberSV.GetById(id);
            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] MemberEditRequest request)
        {
            try
            {
                var member = await _memberSV.Update(id, request);
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Creat-AddreesMember")]
        public async Task<ActionResult> AddAdreesMember([FromRoute]string memberId, [FromForm] AddressMemberCreateRequest request)
        {
            var member = await _memberSV.AddAddress(memberId, request);
            return Ok(member);
        }

        [HttpPost("Creat-Contact")]
        public async Task<ActionResult> ContactMember([FromRoute] string memberId, [FromForm] ContactMemberCreateRequest request)
        {
            var member = await _memberSV.AddContact(memberId, request);
            return Ok(member);
        }

        [HttpPost("Creat-Role")]
        public async Task<ActionResult> RoleMember([FromRoute] string memberId, [FromForm] RoleMemberCreateRequest request)
        {
            var member = await _memberSV.AddRole(memberId, request);
            return Ok(member);
        }
    }
}
