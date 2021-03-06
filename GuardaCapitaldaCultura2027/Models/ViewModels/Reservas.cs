using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GuardaCapitaldaCultura2027.Models.ViewModels
{
    public class Reservas
    {
        public IEnumerable<Reserva> ListaReservas { get; set; }
        public InfoPaginacao Paginacao { get; set; }

        public Reservas(GuardaEventosBdContext context)
        {
            Paginacao = new InfoPaginacao()
            {
                TotalElementos = context.Reservas.Count(),
                ElementosPorPagina = 5,
                PaginaAtual = 1
            };
        }
    }
}