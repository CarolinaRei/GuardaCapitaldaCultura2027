using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Evento
    {
        [Key]
        public int EventosId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public int Descricao { get; set; }

        public int Data_realizacao { get; set; }

        public int Lotacao_max { get; set; }

        public int Local_ocupacao { get; set; }
    }
}
