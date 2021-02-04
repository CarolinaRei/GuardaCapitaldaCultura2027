using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GuardaCapitaldaCultura2027.Models
{
    public class Contacto 
    {
        private const string sms = "Por favor digite um email válido";

        //public static string Nome { get; internal set; }
        public int ContactoId { get; set; }

        [Required(ErrorMessage = "Por favor, insira seu Nome")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres e um máximo de 20")]//aceita maximo 80 carateries e no minimo 2 carater
        [Display(Name = "Nome *", Prompt = " ")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Por favor, insira o seu Sobrenome")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O Sobrenome deve ter pelo menos 2 caracteres e um máximo de 20")]//aceita maximo 80 carateries e no minimo 2 carater
        [Display(Name = "Sobrenome *", Prompt = " ")]
        public string Sobrenome { get; set; }



        [Required(ErrorMessage = sms)]
        [EmailAddress(ErrorMessage = sms)]
        [Display(Name = "Email *", Prompt = " ")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Por favor, insira o seu Assunto")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Assunto deve ter pelo menos 4 caracteres e um máximo de 100")]
        [Display(Name = "Assunto *", Prompt = " ")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "Por favor, insira a sua Mensagem")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Mensagem deve ter pelo menos 2 caracteres e um máximo de 1000")]
        [Display(Name = "Mensagem *", Prompt = " ")]
        public string Mensagem { get; set; }


        public bool Verificado { get; set; }

        [Display(Name = "Resposta *", Prompt = " ")]
        public string Resposta { get; set; }

    }
}
