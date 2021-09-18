
using MemberManagement.Services.Families;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MemberManagerment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilySV _familySV;
        public FamiliesController(IFamilySV familySV)
        {
            _familySV = familySV;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var family = await _familySV.getAll();
            return Ok(family);
        }


        [HttpGet("paging")]
        public async Task<IActionResult> GetPaing([FromQuery]GetFamilyPagingRequest request)
        {
            var family = await _familySV.GetPagedResult(request);
            return Ok(family);
        }

        [HttpPost("Creat-Family")]
        public async Task<ActionResult> Create([FromBody] FamilyCreatRequest request)
        {
            var family = await _familySV.Create(request);
            return Ok("Tạo mới thành công");
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] int id)
        {
            var family = await _familySV.Delete(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromForm] int id)

        {
            var family = await _familySV.GetById(id);
            return Ok(family);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FamilyEditRequest request)
        {
            try
            {
                var member = await _familySV.Update(id, request);
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
