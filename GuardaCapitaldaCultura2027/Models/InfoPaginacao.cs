using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class InfoPaginacao
    {        
        public int TotalElementos { get; set; } = 5;

        public int ElementosPorPagina { get; set; } = 5;

        public int PaginaAtual { get; set; }

        public int TotalPaginas => (int)Math.Ceiling((double)TotalElementos / ElementosPorPagina);
        
        public bool TemPaginaAnterior => (PaginaAtual > 1);

        public bool TemProximaPagina => (PaginaAtual < TotalPaginas);
    }
}
