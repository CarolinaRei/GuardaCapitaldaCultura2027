using GuardaCapitaldaCultura2027.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class SeedDataMunicipio
    {
        internal static void Populate(GuardaEventosBdContext dbContext)
        {
            PopulateMunicipio(dbContext);
        }
        private static void PopulateMunicipio(GuardaEventosBdContext dbContext)
        {
            if (dbContext.Municipios.Any())
            {
                return;
            }
            dbContext.Municipios.AddRange(
                new Municipio
                {
                    Nome ="Guarda",
                    ImagemNome= "~/img/guarda.jpg"

                },
                new Municipio
                {
                    Nome = "Aguiar da Beira",
                    ImagemNome = "~/img/Aguiar-da-Beira-Largo-Monumentos.jpg"
                },
                new Municipio
                {
                    Nome = "Celorico da Beira",
                    ImagemNome = "~/img/celorico.jpg"
                },
                  new Municipio
                  {
                      Nome = "Covilhã",
                      ImagemNome = "~/img/covilha.jpg"
                  },
                new Municipio
                {
                    Nome = "Fundão",
                    ImagemNome = "~/img/fundao.jpg"
                },
                new Municipio
                {
                    Nome = "Sabugal",
                    ImagemNome = "~/img/Sabugal.jpg"
                },
                new Municipio
                {
                    Nome = "Trancoso",
                    ImagemNome = "~/img/trancoso.jpg"
                }
            );
            dbContext.SaveChanges();
        }
    }
}
