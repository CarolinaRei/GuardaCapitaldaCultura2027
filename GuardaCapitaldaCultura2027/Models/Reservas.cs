using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Reservas
    {
        [Key]
        public int ReservarId { get; set; }

        //TuristaID
        [ForeignKey("FK_TuristaId")]
        [Display(Name = "Turista")]
        public int TuristaId { get; set; }

        // public Turista Turista { get; set; }

        // public ICollection<Turista> Turistas { get; set; }

        //EventoID
        [ForeignKey("FK_EventosId")]
        public int EventosId { get; set; }

        public Evento Evento { get; set; }

        public ICollection<Evento> Eventos { get; set; }


        //Feedback

    }
}
