using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZadanieLaboratoryjneDotNet.Model;
using ZadanieLaboratoryjneDotNet.Model.Models;

namespace ZadanieLaboratoryjneDotNet.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        protected DatabaseContext Context { get; set; }

        public CategoriesRepository(DatabaseContext db)
        {
            Context = db;
        }

        public IList<Category> GetAllCategories()
        {
            return Context.Categories.ToList();
        }

        public Category InsertCategory(Category kategoria)
        {
            Context.Categories.Add(kategoria);
            Context.SaveChanges();
            return kategoria;
        }
    }
}
