
using MemberManagement.Services.Families;
using MemberManagerment.ViewModels.FamilyViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var family = await _familySV.getAll();
            return Ok(family);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FamilyCreatRequest request)
        {
            var family = await _familySV.Create(request);
<<<<<<< HEAD
            return Ok();
=======
            return Ok(family);
>>>>>>> 2652236bafecbe3bfa6c7e9d59769d0a8833df17
        }
    }
}
