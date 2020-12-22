using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class MunicipioListViewModel
    {
        public IEnumerable<Municipio> Municipios { get; set; }
        public InfoPaginacao Pagination { get; set; }
    }
}
