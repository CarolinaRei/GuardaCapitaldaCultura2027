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
