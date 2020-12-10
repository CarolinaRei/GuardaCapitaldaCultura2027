﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class Muicipio
    {
        [Key]
        public int MuicipioId { get; set; }

        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Imagem Nome")]
        public string ImagemNome { get; set; }


        [NotMapped]
        [DisplayName("Update File")]
        public IFormFile ImageFile { get; set; }
    }
}