using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage = "Por favor, insira seu Nome")]
        [Display(Name = "Nome do Municipio *", Prompt = "Nome Municipio Enter")]
        public string Nome { get; set; }

       
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Imagem Nome")]
        public string ImagemNome { get; set; }

        [NotMapped]
        [DisplayName("Enviar Ficheiro")]
        [Required(ErrorMessage = "Por favor, Selecine o Ficheiro")]
        public IFormFile ImageFile { get; set; }

        List<Evento> Eventos;
    }
}
