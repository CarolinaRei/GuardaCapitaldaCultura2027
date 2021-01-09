using GuardaCapitaldaCultura2027.Models.Context;
using System;
using System.Collections.Generic;
using System.IO;
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
            Random rnd = new Random();
            int foto_nome = rnd.Next(1, 5);
            byte[] fotogafia = File.ReadAllBytes("./Image/" + foto_nome + ".jpg");
            
            dbContext.Municipios.AddRange(
                new Municipio
                {
                    Nome ="Guarda",
                    Descricao = "Guarda Guarda Guarda Guarda Guarda Guarda",
                    Desativar = true,
                    Imagem = fotogafia
                },
                new Municipio
                {
                    Nome = "Trancoso",
                    Descricao = "Trancoso Trancoso Trancoso Trancoso Trancoso",
                    Desativar = true,
                    Imagem = fotogafia
                }
            );
            dbContext.SaveChanges();
        }
    }
}
