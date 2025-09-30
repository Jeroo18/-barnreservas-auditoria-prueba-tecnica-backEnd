using Banreservas.ReservationHapiness.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Banreservas.ReservationHapiness.Identity.Seed
{
    public static class SeedDefaultUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            // Usuario administrador por defecto
            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Banreservas",
                UserName = "admin",
                Email = "admin@banreservas.com",
                EmailConfirmed = true
            };

            var existingAdmin = await userManager.FindByEmailAsync(adminUser.Email);

            if (existingAdmin == null)
            {
                await userManager.CreateAsync(adminUser, "Admin@123456");
            }

            // Usuario de prueba adicional
            var testUser = new ApplicationUser
            {
                FirstName = "Usuario",
                LastName = "Prueba",
                UserName = "usuario",
                Email = "usuario@test.com",
                EmailConfirmed = true
            };

            var existingTest = await userManager.FindByEmailAsync(testUser.Email);

            if (existingTest == null)
            {
                await userManager.CreateAsync(testUser, "Usuario@123");
            }
        }
    }
}