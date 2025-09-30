//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;

//namespace Banreservas.ReservationHapiness.Persistence
//{
//    public class ReservationHappinessDbContextFactory : IDesignTimeDbContextFactory<ReservationHappinessDbContext>
//    {
//        public ReservationHappinessDbContext CreateDbContext(string[] args)
//        {
//            // Build configuration from appsettings.json
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: true) // optional if you want to avoid failure on missing file
//                .Build();

//            var builder = new DbContextOptionsBuilder<ReservationHappinessDbContext>();

//            var connectionString = configuration.GetConnectionString("DefaultConnection");

//            builder.UseSqlServer(connectionString);

//            // Return context WITHOUT ILoggedInUserService (EF doesn't need it for migrations)
//            return new ReservationHappinessDbContext(builder.Options);
//        }
//    }
//}
