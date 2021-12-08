using MemberManagement.Services.User;
using MemberManagement.ViewModels.RoleAppVM;
using MemberManagement.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static ManaberManagement.Utilities.SystemConstants;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserSV _userService;

        public UsersController(IUserSV userService)
        {
            _userService = userService;
        }
       
        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var userServer = await _userService.GetUsersPaging(request);
            return Ok(userServer);
            // return await _connext.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var userServer = await _userService.GetById(id);
            return Ok(userServer);
            // return await _connext.Products.ToListAsync();
        }


        [HttpGet("GetByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetName(string name)
        {
            var userServer = await _userService.GetByName(name);
            return Ok(userServer);
            // return await _connext.Products.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.ResultObj);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(int id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        

    }
}
