using System;
using System.Collections.Generic;


using System.ComponentModel.DataAnnotations;

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
        public int ReservaId { get; set; }

        public string Numero_Reserva { get; set; }

        public string FeedBack { get; set; }

        [Display(Name = "FeedBack")]
        [Required(ErrorMessage = "Por favor, insira o seu FeedBack")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O FeedBack deve ter entre 3 e 20 caracteres")]

        public ICollection<Evento> Eventos { get; set; }
        public ICollection<Turista> Turistas { get; set; }



    }
}
