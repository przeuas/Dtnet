using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZadanieLaboratoryjneDotNet.Model.Models;

namespace ZadanieLaboratoryjneDotNet.Repository
{
    public interface ICategoriesRepository
    {
        IList<Category> GetAllCategories();
        Category InsertCategory(Category kategoria);
    }
}
