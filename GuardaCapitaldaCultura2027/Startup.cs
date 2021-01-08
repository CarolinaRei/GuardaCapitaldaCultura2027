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
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //DB Contacto
            services.AddDbContext<GuardaEventosBdContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GuardaEventosConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            PopularBaseDadosAsync(app.ApplicationServices);
        }

        /// <summary>
        /// Recria os dados da base de dados que foram apagados se esta estiver vazia.
        /// </summary>
        /// <param name="serviceProvider"></param>
        private async Task PopularBaseDadosAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<GuardaEventosBdContext>();

                if (!db.Municipios.Any())
                {
                    db.Municipios.AddRange(new List<Municipio>() {
                        new Municipio()
                        {
                            Nome = "Meda",
                            ImagemNome = "meda.jpg"
                        }
                    });
                    await db.SaveChangesAsync();
                }

                if (!db.Eventos.Any())
                {
                    db.Eventos.AddRange(new List<Evento>() {
                        new Evento()
                        {
                            Name = "Meda+",
                            MunicipioId = db.Municipios.Where(m=>m.Nome.Equals("Meda")).FirstOrDefault().MunicipioId,
                            Data_realizacao = DateTime.Now,
                            Descricao = "Festival Meda+",
                            Lotacao_max = 100
                        }
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
