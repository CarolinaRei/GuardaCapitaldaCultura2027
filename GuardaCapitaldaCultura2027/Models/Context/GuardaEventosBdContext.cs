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

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Muicipio> Muicipios { get; set; }

        public DbSet<Turista> Turistas { get; set; }




    }
}
