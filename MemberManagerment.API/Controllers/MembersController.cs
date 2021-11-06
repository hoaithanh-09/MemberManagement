
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
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var family = await _memberSV.GetAll();
            return Ok(family);
        }

        public MembersController(IMemberSV memberSV)
        {
            _memberSV = memberSV;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery]MemberPaingRequest request)
        {
            var member = await _memberSV.GetAllPaging(request);
            return Ok(member);
        }
        

        [HttpPost("Create-Member")]
        public async Task<ActionResult> Create([FromForm] MemberCreatRequest request)
        {
            var member = await _memberSV.Create(request);
            return Ok(member.ResultObj);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromRoute] int id)

        {
            var member = await _memberSV.GetById(id);
            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MemberEditRequest request)
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
        public async Task<ActionResult> AddAdreesMember([FromRoute]int memberId, [FromForm] AddressMemberCreateRequest request)
        {
            var member = await _memberSV.AddAddress(memberId, request);
            return Ok(member);
        }

        [HttpPost("Creat-Contact")]
        public async Task<ActionResult> ContactMember([FromRoute] int memberId, [FromForm] ContactMemberCreateRequest request)
        {
            var member = await _memberSV.AddContact(memberId, request);
            return Ok(member);
        }

        [HttpPost("Creat-Role")]
        public async Task<ActionResult> RoleMember([FromRoute] int memberId, [FromForm] RoleMemberCreateRequest request)
        {
            var member = await _memberSV.AddRole(memberId, request);
            return Ok(member);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var group = await _memberSV.Delete(id);
            return Ok(group);
        }
    }
}
