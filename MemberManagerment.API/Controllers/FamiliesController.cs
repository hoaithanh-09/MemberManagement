
using MemberManagement.Services.Families;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
using Microsoft.AspNetCore.Mvc;
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
        [HttpDelete("Delete-Family")]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            var family = await _familySV.Delete(id);
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromForm] string id)
        {
            var family = await _familySV.GetById(id);
            return Ok(family);
        }
    }
}
