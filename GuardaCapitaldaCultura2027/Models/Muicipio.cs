using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Muicipio
    {
        [Key]
        public int MunicipioId { get; set; }

        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImagemNome { get; set; } 
    }
}
