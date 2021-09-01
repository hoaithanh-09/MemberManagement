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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var group = await _groupSV.GetAll();
            return Ok(group);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GroupCreateRequest request)
        {
            var group = await _groupSV.Create(request);
            return Ok();
        }
    }
}
