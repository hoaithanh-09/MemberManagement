
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
<<<<<<< HEAD
        [HttpPost("Create")]
=======
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaing([FromQuery]GetFamilyPagingRequest request)
        {
            var family = await _familySV.GetPagedResult(request);
            return Ok(family);
        }
        [HttpPost("Creat-Family")]
>>>>>>> paging
        public async Task<ActionResult> Create([FromBody] FamilyCreatRequest request)
        {
            var family = await _familySV.Create(request);
            return Ok("Tạo mới thành công");
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            var family = await _familySV.Delete(id);
            return Ok();
        }
        
<<<<<<< HEAD
        [HttpGet("GetById")]
        public async Task<ActionResult> getID([FromBody] string id)
=======
        [HttpGet("{id}")]
        public async Task<ActionResult> getID([FromForm] string id)
>>>>>>> paging
        {
            var family = await _familySV.GetById(id);
            return Ok(family);
        }
    }
}
