using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Guarda
    {
        public int GuardaId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        
        public int Ano { get; set; }

    }
}
