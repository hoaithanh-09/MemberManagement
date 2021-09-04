
using MemberManagement.Services.Members;
using MemberManagement.ViewModels.MemberViewModels;
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

    }
}
