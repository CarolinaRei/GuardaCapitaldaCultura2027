using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;

namespace GuardaCapitaldaCultura2027.Models.ViewModels
{
    public class RestricoesCovid
    {
        public IEnumerable<RestricaoCovid> ListaRestricoes { get; set; }
        public InfoPaginacao Paginacao { get; set; }

        public RestricoesCovid(GuardaEventosBdContext context)
        {
            Paginacao = new InfoPaginacao()
            {
                TotalElementos = context.RestricaoCovid.Count(),
                ElementosPorPagina = 7,
                PaginaAtual = 1
            };
        }
    }
}
