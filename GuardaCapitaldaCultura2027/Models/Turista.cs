using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Turista
    {
        public int TuristaId { get; set; }

        [Required(ErrorMessage = "Por favor, insira o seu Nome")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres")]
        [Display(Name = "Nome *", Prompt = "Nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Por favor, insira o seu Sobrenome")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O sobrenome deve ter entre 2 e 50 caracteres")]
        [Display(Name = "Sobrenome *", Prompt = "Sobrenome")]
        public String Sobrenome { get; set; }

        [Required(ErrorMessage = "Por favor, insira o seu Contacto")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O seu contacto deve ter apenas 9 caracteres")]
        [Display(Name = "Contacto *", Prompt = "Contacto")]
        public int Contacto { get; set; }

        [Required(ErrorMessage = "Por favor, insira o seu Email")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "O seu contacto deve ter entre 12 e 50 caracteres")]
        [Display(Name = "Email *", Prompt = "Email")]
        // if para caracteres obrigatório "@, ."
        public String Email { get; set; }

        [Required(ErrorMessage = "Por favor, defina a sua Password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "O seu contacto deve ter entre 8 e 20 caracteres")]
        [Display(Name = "Password *", Prompt = "Password")]
        // Esconder password
        public String Password { get; set; }
    }
}
