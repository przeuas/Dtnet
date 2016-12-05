using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZadanieLaboratoryjneDotNet.Model.Models
{
    public class News
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Kategoria { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual string Tytul{ get; set; }
        public virtual string Opis { get; set; }
    }
}
