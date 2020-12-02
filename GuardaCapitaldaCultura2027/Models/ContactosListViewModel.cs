using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class ContactosListViewModel: PagingInfo
    {
        //public IEnumerable<Contacto> Contactos { get; set; }

        //public PagingInfo Pagination { get; set; }

        public List<Contacto> Contactos { get; set; }

    }
}
