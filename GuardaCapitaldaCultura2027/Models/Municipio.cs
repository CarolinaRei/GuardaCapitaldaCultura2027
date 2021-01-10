using Microsoft.AspNetCore.Http;
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
        [Display(Name = "Nome do Municipio ", Prompt = "Nome Municipio ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, insira Data")]
        [Display(Name = "Data da Imagem do Municipio", Prompt = "Data da Imagem")]
        public DateTime Data_imagem { get; set; }


        
        [Required(ErrorMessage = "Por favor, insira o estado do Municipio")]
        [Display(Name = "Estado do Municipio ", Prompt = "Estado do Municipio")]
        public bool Desativar { get; set; }

        [Required(ErrorMessage = "Por favor, insira sua Descrição")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Assunto deve ter pelo menos 2 caracteres e um máximo de 1000")]
        [Display(Name = "Descrição do Municipio ", Prompt = "Descrição do Municipio Enter")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Por favor, insira Imagem do Municipio")]
        [Display(Name = "Imagem do Municipio ", Prompt = "Imagem do Municipio")]
        public byte[] Imagem { get; set; }


        /*[Column(TypeName = "nvarchar(100)")]
        [Display(Name ="Imagem Nome")]
        public string ImagemNome { get; set; }


        [NotMapped]
        [Display(Name="Enviar Ficheiro *")]
        [Required(ErrorMessage = "Por favor, Selecine o Ficheiro")]
        public IFormFile ImageFile { get; set; }
        */
    }
}
