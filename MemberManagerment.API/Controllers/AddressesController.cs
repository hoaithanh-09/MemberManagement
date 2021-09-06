using MemberManagement.Services.Addresses;
using MemberManagement.ViewModels.AddressViewModels;
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
    public class AddressesController : ControllerBase
    {
        private readonly IAddressSV _address;
        public AddressesController(IAddressSV address)
        {
            _address = address;
        }
      

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaing([FromQuery] GetAddressPagingRequest request)
        {
            var family = await _address.GetPagedResult(request);
            return Ok(family.Items);
        }
        [HttpPost("Creat-Family")]

        public async Task<ActionResult> Create([FromBody] AddressCreatRequest request)
        {
            var family = await _address.Create(request);
            return Ok("Tạo mới thành công");
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            var family = await _address.Delete(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromQuery] string id)

        {
            var family = await _address.GetById(id);
            return Ok(family);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update( string id, [FromForm] AddressEditRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
           
            var family = await _address.Update(id,request);
            if(family > 0)
            return Ok("cập nhật thành công");

            return Ok("Cập nhật thất bại");
        }
        [HttpPut("{id:string}")]
        public async Task<IActionResult> GetById(string id, [FromForm] AddressEditRequest request)
        {
            try
            {
                var address = await _address.Update2(id, request);

                return Ok(address);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
          

          
        }

    }
}
