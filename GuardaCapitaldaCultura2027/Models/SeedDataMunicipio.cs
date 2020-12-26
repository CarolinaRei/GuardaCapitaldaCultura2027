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
                    ImagemNome= "guarda202028813.jpg"
                    
                },
                new Municipio
                {
                    Nome = "Aguiar da Beira",
                    ImagemNome = "Aguiar-da-Beira-Largo-Monumentos203011164.jpg"
                },
                new Municipio
                {
                    Nome = "Celorico da Beira",
                    ImagemNome = "celorico203044890.jpg"
                },
                  new Municipio
                  {
                      Nome = "Covilhã",
                      ImagemNome = "covilha202901619.jpg"
                  },
                new Municipio
                {
                    Nome = "Fundão",
                    ImagemNome = "fundao203213648.jpg"
                },
                new Municipio
                {
                    Nome = "Sabugal",
                    ImagemNome = "Sabugal202838363.jpg"
                },
                new Municipio
                {
                    Nome = "Trancoso",
                    ImagemNome = "trancoso202743150.jpg"
                }
            );
            dbContext.SaveChanges();
        }
    }
}
