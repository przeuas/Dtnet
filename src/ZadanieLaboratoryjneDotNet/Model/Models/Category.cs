using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZadanieLaboratoryjneDotNet.Model.Models
{
    public class Category
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Nazwa { get; set; }
    }
}
