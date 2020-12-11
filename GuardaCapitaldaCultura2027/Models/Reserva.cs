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

        public ICollection<Evento> Eventos { get; set; }
        public ICollection<Turista> Turistas { get; set; }



    }
}
