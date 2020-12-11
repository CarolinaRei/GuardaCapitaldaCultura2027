using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Reserva
    {
        [Key]
        public int EventosId { get; set; }


        [Display(Name = "Feedback")]
       ")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, insira a Descrição")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]

    }
}
