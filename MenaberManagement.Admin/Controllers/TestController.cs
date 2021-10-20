using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Details()
        {
            return View();
        }
    }
}
