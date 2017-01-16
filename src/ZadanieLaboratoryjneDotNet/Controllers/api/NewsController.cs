using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZadanieLaboratoryjneDotNet.Repository;

namespace ZadanieLaboratoryjneDotNet.Controllers.api
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        /// <summary>
        /// Deklaracja repozoytorium do obsługi newsów
        /// </summary>
        private INewsRepository NewsRepository { get; set; }

        public NewsController(INewsRepository repo)
        {
            // pod zmienną repo kryje się wstrzyknięta gotowa klasa, z której możemy korzystać
            NewsRepository = repo;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return new JsonResult(new
            {
                success = true,
                data = NewsRepository.GetAllNews()
            });
        }
    }
}
