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
        protected DatabaseContext Context { get; set; }

        public NewsRepository(DatabaseContext db)
        {
            Context = db;
        }

        public IList<News> GetAllNews()
        {
            return Context.News.ToList();
        }
    }
}
