using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZadanieLaboratoryjneDotNet.Model.Models;

namespace ZadanieLaboratoryjneDotNet.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=ZadanieDotNet.db");
        }
    }
}
