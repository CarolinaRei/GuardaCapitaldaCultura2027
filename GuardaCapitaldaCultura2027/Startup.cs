using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GuardaCapitaldaCultura2027.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GuardaCapitaldaCultura2027.Models.Context;
using GuardaCapitaldaCultura2027.Models;
using System.IO;

namespace GuardaCapitaldaCultura2027
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //DB Contacto
            services.AddDbContext<GuardaEventosBdContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GuardaEventosConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            // Recria dados necessarios para inicializar a base de dados
            PopularBaseDados(app.ApplicationServices, userManager, roleManager);
        }

        /// <summary>
        /// Recria os dados da base de dados que foram apagados se esta estiver vazia.
        /// </summary>
        /// <param name="serviceProvider"></param>
        private void PopularBaseDados(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<GuardaEventosBdContext>();

                string ROLE_GESTORDEEVENTOS = "GestorEventos";
                string ROLE_TURISTA = "Turista";

                IdentityRole gestorEventos = roleManager.FindByNameAsync(ROLE_GESTORDEEVENTOS).GetAwaiter().GetResult();
                IdentityRole turistaRole = roleManager.FindByNameAsync(ROLE_TURISTA).GetAwaiter().GetResult();

                if (gestorEventos == null)
                {
                    IdentityRole role = new IdentityRole(ROLE_GESTORDEEVENTOS);
                    roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }

                if (turistaRole == null)
                {
                    IdentityRole role = new IdentityRole(ROLE_TURISTA);
                    roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }

                IdentityUser gestorUser = userManager.FindByNameAsync("Gestor").GetAwaiter().GetResult();

                if (gestorUser == null)
                {
                    gestorUser = new IdentityUser("Gestor");
                    userManager.CreateAsync(gestorUser, "Secret123$").GetAwaiter().GetResult();

                    if (!userManager.IsInRoleAsync(gestorUser, ROLE_GESTORDEEVENTOS).GetAwaiter().GetResult())
                    {
                        userManager.AddToRoleAsync(gestorUser, ROLE_GESTORDEEVENTOS).GetAwaiter().GetResult();
                    }
                }

                IdentityUser turistaUser = userManager.FindByNameAsync("Carolina").GetAwaiter().GetResult();

                if (turistaUser == null)
                {
                    turistaUser = new IdentityUser("Carolina");
                    userManager.CreateAsync(turistaUser, "Secret123$").GetAwaiter().GetResult();

                    if (!userManager.IsInRoleAsync(turistaUser, ROLE_TURISTA).GetAwaiter().GetResult())
                    {
                        userManager.AddToRoleAsync(turistaUser, ROLE_TURISTA).GetAwaiter().GetResult();
                    }
                }

                if (!db.Municipios.Any())
                {
                    db.Municipios.AddRange(new List<Municipio>() {
                    new Municipio
                    {
                        Nome ="Guarda",
                        Descricao ="Guarda",
                        ImagemNome= "~/img/guarda.jpg"

                    },
                    new Municipio
                    {
                        Nome = "Aguiar da Beira",
                        Descricao ="Aguiar da Beira",
                        ImagemNome = "~/img/Aguiar-da-Beira-Largo-Monumentos.jpg"
                    },
                    new Municipio
                    {
                        Nome = "Celorico da Beira",
                        Descricao ="Celorico da Beira",
                        ImagemNome = "~/img/celorico.jpg"
                    },
                      new Municipio
                      {
                          Nome = "Covilhã",
                        Descricao ="Covilhã",
                          ImagemNome = "~/img/covilha.jpg"
                      },
                    new Municipio
                    {
                        Nome = "Fundão",
                        Descricao ="Fundão",
                        ImagemNome = "~/img/fundao.jpg"
                    },
                    new Municipio
                    {
                        Nome = "Sabugal",
                        Descricao ="Sabugal",
                        ImagemNome = "~/img/Sabugal.jpg"
                    },
                    new Municipio
                    {
                        Nome = "Trancoso",
                        Descricao ="Trancoso",
                        ImagemNome = "~/img/trancoso.jpg"
                    },
                    new Municipio
                    {
                        Nome = "Meda",
                        Descricao ="Meda",
                        ImagemNome = "~/img/meda.jpg"
                    }
                        });
                    db.SaveChanges();
                }

                if (!db.Eventos.Any())
                {
                    var file = File.OpenRead("wwwroot/img/meda.jpg");
                    byte[] b = new byte[file.Length];
                    file.Read(b);

                    db.Eventos.AddRange(new List<Evento>() {
                            new Evento()
                            {
                                Name = "Meda+",
                                MunicipioId = db.Municipios.Where(m=>m.Nome.Equals("Meda")).FirstOrDefault().MunicipioId,
                                Data_realizacao = DateTime.Now,
                                Descricao = "Festival Meda+",
                                Lotacao_max = 100,
                                Imagem = b
                            }
                        });
                    db.SaveChanges();
                }
            }
        }
    }
}