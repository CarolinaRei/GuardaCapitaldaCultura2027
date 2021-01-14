using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class RestricaoCovid
    {
        [Key]
        public int RestricaoCovidId { get; set; }

        [Required(ErrorMessage = "Por favor, insira o seu Nome")]
        [Display(Name = "Descrição")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "A descrição deve ter entre 20 e 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, insira a data inicial")]
        [Display(Name = "Início")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Por favor, insira a data final")]
        [Display(Name = "Final")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataFim { get; set; }
    }
}
