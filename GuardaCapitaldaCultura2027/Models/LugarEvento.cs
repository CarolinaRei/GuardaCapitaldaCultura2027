﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class LugarEvento
    {
        public int LugarEventoId { get; set; }

        public bool Ocupado { get; set; }


        [Required(ErrorMessage = "Insira o Numero de cadeira")]
        [RegularExpression("[1-9][0-9]{0,2}", ErrorMessage = "Por favor Insira o número de Cadeira valido")]

        public string NumeroCadeira { get; set; }
    }
}
