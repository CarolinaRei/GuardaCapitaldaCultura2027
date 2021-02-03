using System.Collections.Generic;
using System.Linq;
using GuardaCapitaldaCultura2027.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GuardaCapitaldaCultura2027.Models.ViewModels
{
    /// <summary>
    /// Eventos do municipio
    /// </summary>
    /// <remarks>Autor(a): Carolina Rei</remarks>
    public class EventosMunicipio
    {
        public IEnumerable<Evento> ListaEventos { get; set; }
        public InfoPaginacao Paginacao { get; set; }

        /// <summary>
        /// Eventos do municipio
        /// </summary>
        /// <remarks>Autor(a): Carolina Rei</remarks>
        /// <remarks>Ja tem filtro feito através do nome do municipio</remarks>
        /// <param name="context">Base de dados</param>
        /// <param name="Municipio">Nome do municipio</param>
        public EventosMunicipio(GuardaEventosBdContext context, string Municipio)
        {
            ListaEventos = context.Eventos.Include(evt => evt.Municipio).Where(e => e.Municipio.Nome.ToLower().Trim().Equals(Municipio.ToLower().Trim())).ToList();
            Paginacao = new InfoPaginacao()
            {
                TotalElementos = context.Eventos.Include(evt => evt.Municipio).Where(e => e.Municipio.Nome.ToLower().Trim().Equals(Municipio.ToLower().Trim())).Count(),
                ElementosPorPagina = 3,
                PaginaAtual = 1
            };
        }
    }
}