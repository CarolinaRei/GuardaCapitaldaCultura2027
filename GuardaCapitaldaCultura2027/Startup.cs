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
                    Configuration.GetConnectionString("GuardaUsersConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(
                options => {
                    //Sign in 
                    options.SignIn.RequireConfirmedAccount = false;

                    //Password
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 6;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;


                    //Lockout
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(40);
                    options.Lockout.MaxFailedAccessAttempts = 6;
                    
               }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI();


            services.AddControllersWithViews();
            services.AddRazorPages();

            //DB Contacto
            services.AddDbContext<GuardaEventosBdContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GuardaEventosConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,

            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager

            // GuardaEventosBdContext bd,
            // UserManager<IdentityUser> userManager,
            // RoleManager<IdentityRole> roleManager
            )
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

            // SeedDataGestorEventos.SeedRolesAsync(roleManager).Wait();
            // SeedDataGestorEventos.SeedDefaultAdminAsync(userManager).Wait();
            SeedDataUser.SeedRolesAsync(roleManager).Wait();
            SeedDataUser.SeedDefaultAdminAsync(userManager).Wait();
           
            if (env.IsDevelopment())
            {
                // SeedDataGestorEventos.SeedDevData(db);
                // SeedDataGestorEventos.SeedDevUsersAsync(userManager).Wait();
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetService<GuardaEventosBdContext>();
                    SeedDataMunicipio.Populate(dbContext);
                }
            }
        }
    }
}