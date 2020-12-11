using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardaCapitaldaCultura2027.Models;

namespace GuardaCapitaldaCultura2027.Models.Context
{
    public class GuardaEventosBdContext : DbContext
    {
        public GuardaEventosBdContext(DbContextOptions options) : base(options) { }
        //public DbSet<GuardaCapitaldaCultura2027.Models.Evento> Evento { get; set; }

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Evento> Evento { get; set; }


        public DbSet<Muicipio> Muicipios { get; set; }


    }
}
