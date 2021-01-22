/*using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Data
{
    public class SeedDataGestorEventos
    {
        private const string DEFAULT_ADMIN_USER = "admin@ipg.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "Secret123§";

        private const string ROLE_ADMINISTRATOR = "Admin";

        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD, ROLE_ADMINISTRATOR);
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
            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRATOR);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        /*internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {
        }*/

        /*internal static void SeedDevData(GuardaEventosBdContext db)
        {
            if (db.Customer.Any()) return;

            db.Customer.Add(new Customer
            {
                Name = "Mary",
                Email = "mary@ipg.pt"
            });

            db.SaveChanges();
        }
    }
}*/
