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
    public class SeedDataReserva
    {
        public static void Populate(GuardaEventosBdContext db, UserManager<IdentityUser> userManager)
        {
            if (!db.Reservas.Any())
            {
                string id = userManager.FindByNameAsync("carolina@ipg.pt").GetAwaiter().GetResult().Id;
                db.Reservas.AddRange(new List<Reserva>() {
                            SeedDataReserva.CriarReserva(db,id,"Antonia Jesus","Mêda","Festival Mêda+"),
                            SeedDataReserva.CriarReserva(db,id,"Maria Brito","Mêda","Festival Mêda+"),
                            SeedDataReserva.CriarReserva(db,id,"Manuel Lopes","Mêda","Festival Mêda+"),
                            });
                db.SaveChanges(); 
                
                db.Reservas.AddRange(new List<Reserva>() {
                             SeedDataReserva.CriarReserva(db,id,"Noelia Maria","Guarda","Festival Guarda+"),
                            SeedDataReserva.CriarReserva(db,id,"Micael Rocha","Guarda","Festival Guarda+"),
                            SeedDataReserva.CriarReserva(db,id,"Nelson Carlos","Guarda","Festival Guarda+"),
                            });
                db.SaveChanges();
                
                db.Reservas.AddRange(new List<Reserva>() {
                            SeedDataReserva.CriarReserva(db,id,"Filipe Moura","Trancoso","Festival Trancoso+"),
                            SeedDataReserva.CriarReserva(db,id,"Joao Pedro","Almeida","Festival Almeida+"),
                            SeedDataReserva.CriarReserva(db,id,"Carlos Manuel","Belmonte","Festival Belmonte+"),
                            });
                db.SaveChanges(); 
                
                db.Reservas.AddRange(new List<Reserva>() {
                            SeedDataReserva.CriarReserva(db,id,"Rita Mendes","Celorico da Beira","Festival Celorico da Beira+"),
                            SeedDataReserva.CriarReserva(db,id,"Maria Saraiva","Covilhã","Festival Covilhã+"),
                            SeedDataReserva.CriarReserva(db,id,"Mariana Pereira","Figueira de Castelo Rodrigo","Festival FCR+"),
                            });
                db.SaveChanges(); 
                
                db.Reservas.AddRange(new List<Reserva>() {
                            SeedDataReserva.CriarReserva(db,id,"Pedro Rei","Manteigas","Festival Manteigas+"),
                            });
                db.SaveChanges(); 
                
                db.Reservas.AddRange(new List<Reserva>() {
                             SeedDataReserva.CriarReserva(db,id,"Francisca Dinis","Pinhel","Festival Pinhel+"),
                            SeedDataReserva.CriarReserva(db,id,"Sofia Martins","Sabugal","Festival Sabugal+"),
                            SeedDataReserva.CriarReserva(db,id,"Filipa Morgado","Seia","Festival Seia+"),
                         });
                db.SaveChanges();

                db.Reservas.AddRange(new List<Reserva>() {
                        SeedDataReserva.CriarReserva(db,id,"Joana Rodrigues","Vila Nova de Foz Côa","Festival Vila Nova de Foz Côa+")
                        });
                db.SaveChanges();
            }
        }

        private static Reserva CriarReserva(GuardaEventosBdContext db, string id, string nome, string evento, string observacao)
        {
            using FileStream file = File.OpenRead($"Image/{new Random().Next(14) + 1}.jpg");
            byte[] b = new byte[file.Length];
            file.Read(b);

            return new Reserva()
            {
                Nome = nome,
                EventoId = db.Eventos.ToList().Where(evt => evt.Name.ToLower().Equals(evento.ToLower().Split(' ')[0])).FirstOrDefault().EventoId,
                Numero_Reserva = new Random().Next(4),
                Observacao = observacao,
                PessoaId = id
            };
        }
    }
}
