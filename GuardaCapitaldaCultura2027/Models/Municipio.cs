using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioId { get; set; }


        [Required(ErrorMessage = "Por favor, insira o Nome do Municipio")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres e um máximo de 20")]
        [Display(Name = "Nome *", Prompt = "Nome Municipio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, insira a Descrição do Municipio")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres e um máximo de 1000")]
        [Display(Name = "Descrição *", Prompt = "Descrição do Municipio")]
        public string Descricao { get; set; }


        public byte[] Imagem { get; set; }

    }
}
