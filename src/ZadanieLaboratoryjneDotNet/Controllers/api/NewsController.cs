using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZadanieLaboratoryjneDotNet.Controllers.api
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        [HttpGet]
        public ActionResult ApiTest()
        {
            return new JsonResult(new
            {
                success = true,
                message = "nasze API działa poprawnie"
            });
        }

        [HttpGet("{message}")]
        public ActionResult ApiTest2(string message)
        {
            return new JsonResult(new
            {
                success = true,
                message = message
            });
        }
    }
}
