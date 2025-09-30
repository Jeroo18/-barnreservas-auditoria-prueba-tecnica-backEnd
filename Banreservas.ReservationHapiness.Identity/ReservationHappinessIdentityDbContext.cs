using Banreservas.ReservationHapiness.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Banreservas.ReservationHapiness.Identity
{
    public class ReservationHappinessIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ReservationHappinessIdentityDbContext()
        {

        }

        public ReservationHappinessIdentityDbContext(DbContextOptions<ReservationHappinessIdentityDbContext> options) : base(options)
        {
        }
    }
}
