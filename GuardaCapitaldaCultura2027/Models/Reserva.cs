using System;
using System.Collections.Generic;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        [ForeignKey("FK_EventoId")]
        public int EventoId { get; set; }

        [ForeignKey("FK_TuristaId")]
        public int TuristaId { get; set; }

        [Display(Name = "Nome")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, insira a Descrição")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Numero de Pessoas para a Reserva")]
        public int Numero_Reserva { get; set; }

        public ICollection<Evento> Eventos { get; set; }
        public ICollection<Turista> Turistas { get; set; }
    }
}
