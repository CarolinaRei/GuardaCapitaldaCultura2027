using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;

namespace GuardaCapitaldaCultura2027.Models.ViewModels
{
    public class Eventos
    {
        public IEnumerable<Evento> ListaEventos { get; set; }
        public InfoPaginacao Paginacao { get; set; }

        public Eventos(GuardaEventosBdContext context)
        {
            Paginacao = new InfoPaginacao()
            {
                TotalElementos = context.Eventos.Count(),
                ElementosPorPagina = 5,
                PaginaAtual = 1
            };
        }
    }
}