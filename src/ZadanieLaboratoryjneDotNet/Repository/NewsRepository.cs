using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZadanieLaboratoryjneDotNet.Model;
using ZadanieLaboratoryjneDotNet.Model.Models;

namespace ZadanieLaboratoryjneDotNet.Repository
{
    public class NewsRepository : INewsRepository
    {
        // deklaracja kontekstu bazy danych
        protected DatabaseContext Context { get; set; }

        // konstruktor z wstrzykiwaniem bazy danych
        public NewsRepository(DatabaseContext db)
        {
            Context = db;
        }

        // metody operujące na bazie danych
        public IList<News> GetAllNews()
        {
            return Context.News.ToList();
        }
    }
}
