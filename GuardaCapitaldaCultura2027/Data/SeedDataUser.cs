using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Data
{
    public class SeedDataUser
    {
        private const string DEFAULT_ADMIN_USER = "admin@guardaevento.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "GuardaEvento123@";
        private const string ROLE_ADMINISTRADOR = "Admin";
        private const string ROLE_GESTOREVENTO = "GestorEventos";
        private const string ROLE_TURISTA = "Turista";

        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByNameAsync(DEFAULT_ADMIN_USER);

            if(user == null)
            {
                user = new IdentityUser(DEFAULT_ADMIN_USER);
                await userManager.CreateAsync(user, DEFAULT_ADMIN_PASSWORD);
            }
            if (!await userManager.IsInRoleAsync(user, ROLE_ADMINISTRADOR))
            {
               await userManager.AddToRoleAsync(user, ROLE_ADMINISTRADOR);
            }
        }

        internal static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRADOR);

            await EnsureRoleIsCreated(roleManager, ROLE_GESTOREVENTO);

            await EnsureRoleIsCreated(roleManager, ROLE_TURISTA);
           
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
