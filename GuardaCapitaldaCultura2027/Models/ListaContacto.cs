using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class ListaContacto
    {
        public IEnumerable<Contacto> Contactos { get; set; }

        public PagingInfoMunicipio pagination { get; set; }

        public string SearchNome { get; set; }
    }
}
