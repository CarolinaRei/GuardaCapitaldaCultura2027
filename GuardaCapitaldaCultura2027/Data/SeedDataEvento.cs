using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;
using Microsoft.AspNetCore.Identity;

namespace GuardaCapitaldaCultura2027.Data
{
    public class SeedDataEvento
    {
        public static void Populate(GuardaEventosBdContext db)
        {
            if (!db.Eventos.Any())
            {
                db.Eventos.AddRange(new List<Evento>() {
                            SeedDataEvento.CriarEvento(db,"Mêda","Mêda","Festival Mêda+"),
                            SeedDataEvento.CriarEvento(db,"Mêda","Mêda","Festival Mêda+"),
                            SeedDataEvento.CriarEvento(db,"Mêda","Mêda","Festival Mêda+"),
                            });
                db.SaveChangesAsync().GetAwaiter().GetResult();

                db.Eventos.AddRange(new List<Evento>() {
                            SeedDataEvento.CriarEvento(db,"Guarda","Guarda","Festival Guarda+"),
                            SeedDataEvento.CriarEvento(db,"Guarda","Guarda","Festival Guarda+"),
                            SeedDataEvento.CriarEvento(db,"Guarda","Guarda","Festival Guarda+"),
                            });
                db.SaveChangesAsync().GetAwaiter().GetResult();

                db.Eventos.AddRange(new List<Evento>() {
                            SeedDataEvento.CriarEvento(db,"Trancoso","Trancoso","Festival Trancoso+"),
                            SeedDataEvento.CriarEvento(db,"Almeida","Almeida","Festival Almeida+"),
                            SeedDataEvento.CriarEvento(db,"Belmonte","Belmonte","Festival Belmonte+"),
                            });
                db.SaveChangesAsync().GetAwaiter().GetResult();

                db.Eventos.AddRange(new List<Evento>() {
                            SeedDataEvento.CriarEvento(db,"Celorico da Beira","Celorico da Beira","Festival Celorico da Beira+"),
                            SeedDataEvento.CriarEvento(db,"Covilhã","Covilhã","Festival Covilhã+"),
                            SeedDataEvento.CriarEvento(db,"Figueira de Castelo Rodrigo","Figueira de Castelo Rodrigo","Festival FCR+"),
                            });
                db.SaveChangesAsync().GetAwaiter().GetResult();

                db.Eventos.AddRange(new List<Evento>() {
                            SeedDataEvento.CriarEvento(db,"Manteigas","Manteigas","Festival Manteigas+"),
                            SeedDataEvento.CriarEvento(db,"Pinhel","Pinhel","Festival Pinhel+"),
                            SeedDataEvento.CriarEvento(db,"Sabugal","Sabugal","Festival Sabugal+"),
                            });
                db.SaveChangesAsync().GetAwaiter().GetResult();

                db.Eventos.AddRange(new List<Evento>() {
                           SeedDataEvento.CriarEvento(db,"Seia","Seia","Festival Seia+"),
                            SeedDataEvento.CriarEvento(db,"Vila Nova de Foz Côa","Vila Nova de Foz Côa","Festival Vila Nova de Foz Côa+")
                        });
                db.SaveChangesAsync().GetAwaiter().GetResult();
            }
        }

        private static Evento CriarEvento(GuardaEventosBdContext db, string nome, string municipio, string descricao)
        {
            FileStream file = File.OpenRead($"Image/{new Random().Next(14) + 1}.jpg");
            byte[] b = new byte[file.Length];
            file.Read(b);
            file.Close();
            file.Dispose();

            string municipioNomeCurto = municipio.Split(' ', StringSplitOptions.None)[0].ToLower();

            return new Evento()
            {
                Name = nome.Split(' ')[0],
                MunicipioId = db.Municipio.ToList().Where(m => m.Nome.Split(' ', StringSplitOptions.None)[0].ToLower().Equals(municipioNomeCurto)).FirstOrDefault().MunicipioId,
                Data_realizacao = DateTime.Now,
                Descricao = descricao,
                Lotacao_max = 100,
                Imagem = b
            };
        }
    }
}
