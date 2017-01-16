using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZadanieLaboratoryjneDotNet.Model.Models;
using ZadanieLaboratoryjneDotNet.Repository;

namespace ZadanieLaboratoryjneDotNet.Controllers.api
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        // deklaracja repozytorium
        private ICategoriesRepository CategoriesRepository { get; set; }

        // konstruktor z wstrzykiwaniem repo
        public CategoriesController(ICategoriesRepository repo)
        {
            CategoriesRepository = repo;
        }

        // metody do obsługi API - GET / POST
        [HttpGet]
        public ActionResult GetAll()
        {
            return new JsonResult(new
            {
                success = true,
                data = CategoriesRepository.GetAllCategories()
            });
        }

        [HttpPost]
        public ActionResult Post([FromBody] Category kategoria)
        {
            kategoria = CategoriesRepository.InsertCategory(kategoria);
            return new JsonResult(new
            {
                success = kategoria.Id > 0, // jeżeli Id > 0 to oznacza, że rekord został poprawnie dodany i baza zwróciła Id
                data = kategoria
            });
        }
    }
}
