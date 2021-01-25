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
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD, ROLE_ADMINISTRADOR);
        }

        private static async Task EnsureUserIsCreated(UserManager<IdentityUser> userManager, string username, string password, string role)
        {
            IdentityUser user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }
            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
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

        internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {
           await EnsureUserIsCreated(userManager, "vagner@ipg.pt", "Vagner123@", ROLE_GESTOREVENTO);

           await EnsureUserIsCreated(userManager, "mary@ipg.pt", "Mary123@", ROLE_TURISTA);
        }
    }
}
