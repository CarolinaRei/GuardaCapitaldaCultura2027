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

        public string Descricao { get; set; }

        [Display(Name = "Data de Realização")]
        public DateTime Data_realizacao { get; set; }

        [Display(Name = "Lotação Maxima")]
        public int Lotacao_max { get; set; }

        [Display(Name = "Reservado")]
        public bool Local_ocupacao { get; set; }
    }
}
