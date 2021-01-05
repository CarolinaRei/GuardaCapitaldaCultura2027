using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Municipio
    {
        public int MunicipioId { get; set; }

        [Required(ErrorMessage = "Por favor, insira seu Nome")]
        [Display(Name = "Nome do Municipio *", Prompt = "Nome Municipio Enter")]

        public string Nome { get; set; }


        [Required]
        public bool Desativar { get; set; }

        [Required(ErrorMessage = "Por favor, insira sua Descrição")]
        [Display(Name = "Descrição do Municipio *", Prompt = "Descrição do Municipio Enter")]
        public string Descricao { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [Display(Name ="Imagem Nome")]
        public string ImagemNome { get; set; }
    }
}
