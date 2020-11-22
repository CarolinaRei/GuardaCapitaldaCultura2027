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
        public int ContactoId { get; set; }

        [Required(ErrorMessage = "Por favor, insira seu Nome")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres e um máximo de 20")]//aceita maximo 80 carateries e no minimo 2 carater
        [Display(Name = "Nome", Prompt = "Inserir um Nome")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Por favor, insira seu Sobrenome")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O Sobrenome deve ter pelo menos 2 caracteres e um máximo de 20")]//aceita maximo 80 carateries e no minimo 2 carater
        [Display(Name = "Sobrenome", Prompt = "Inserir um Sobrenome")]
        public string Sobrenome { get; set; }



        [Required(ErrorMessage = "Please enter a valid email")]
        [EmailAddress(ErrorMessage = "Por favor digite um email válido")]
        [Display(Name = "Email", Prompt = "Inserir um Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Por favor, insira seu Assunto")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Assunto deve ter pelo menos 4 caracteres e um máximo de 20")]//aceita maximo 20 carateries e no minimo 2 carater
        [Display(Name = "Assunto", Prompt = "Inserir um Assunto")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "Por favor, insira seu Assunto")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Mensagem deve ter pelo menos 2 caracteres e um máximo de 1000")]//aceita maximo 1000 carateries e no minimo 2 carater
        [Display(Name = "Mensagem", Prompt = "Inserir um Mensagem")]
        public string Mensagem { get; set; }
    }
}
