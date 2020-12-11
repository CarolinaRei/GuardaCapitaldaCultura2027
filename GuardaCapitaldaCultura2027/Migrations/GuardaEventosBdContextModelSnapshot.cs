﻿// <auto-generated />
using System;
using GuardaCapitaldaCultura2027.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuardaCapitaldaCultura2027.Migrations
{
    [DbContext(typeof(GuardaEventosBdContext))]
    partial class GuardaEventosBdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Contacto", b =>
                {
                    b.Property<int>("ContactoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ContactoId");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Evento", b =>
                {
                    b.Property<int>("EventosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_realizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("Local_ocupacao")
                        .HasColumnType("bit");

                    b.Property<int>("Lotacao_max")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("EventosId");

                    b.HasIndex("ReservaId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Muicipio", b =>
                {
                    b.Property<int>("MuicipioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventosId")
                        .HasColumnType("int");

                    b.Property<string>("ImagemNome")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MuicipioId");

                    b.HasIndex("EventosId");

                    b.ToTable("Muicipios");
                });

            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FeedBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero_Reserva")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservaId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Turista", b =>
                {
                    b.Property<int>("TuristaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Contacto")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TuristaId");

                    b.HasIndex("ReservaId");

                    b.ToTable("Turista");
                });

<<<<<<< HEAD
            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Evento", b =>
                {
                    b.HasOne("GuardaCapitaldaCultura2027.Models.Reserva", null)
                        .WithMany("Eventos")
                        .HasForeignKey("ReservaId");
                });

            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Turista", b =>
                {
                    b.HasOne("GuardaCapitaldaCultura2027.Models.Reserva", null)
                        .WithMany("Turistas")
                        .HasForeignKey("ReservaId");
=======
            modelBuilder.Entity("GuardaCapitaldaCultura2027.Models.Muicipio", b =>
                {
                    b.HasOne("GuardaCapitaldaCultura2027.Models.Evento", null)
                        .WithMany("Muicipios")
                        .HasForeignKey("EventosId");
>>>>>>> a2f738f7382bd21feaa7d30c8af4403c98261818
                });
#pragma warning restore 612, 618
        }
    }
}
