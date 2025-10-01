using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Banreservas.ReservationHapiness.Application.Interfaces;
using Banreservas.ReservationHapiness.Domain.Common;
using System.Reflection.Emit;
using Banreservas.ReservationHapiness.Domain.Entities;
//using Banreservas.ReservationHapiness.Persistence.Configurations;

namespace Banreservas.ReservationHapiness.Persistence
{
    public class ReservationHappinessDbContext : DbContext
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;
        private readonly ILoggedInUserService? _loggedInUserService;

        #endregion

        #region ===[ Constructors ]=================================================================

        public ReservationHappinessDbContext(DbContextOptions<ReservationHappinessDbContext> options)
        : base(options)
        {
        }

        public ReservationHappinessDbContext(DbContextOptions<ReservationHappinessDbContext> options, ILoggedInUserService loggedInUserService)
          : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        #endregion

        #region ===[ DbSet Entities to database bindings ]=============================================================

        public DbSet<Domain.Entities.Reservation> Reservations { get; set; }

        #endregion

        #region ===[ OnModelCreating builders ]=================================================================
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ReservationHappinessDbContext).Assembly);
        }

        #endregion

        #region ===[ Saves methods ]-----------=================================================================
        public void Save()
        {
            this.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService?.UserId ?? "System";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService?.UserId ?? "System";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region ===[ OnConfiguring methods ]-----------=================================================================

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = _configuration.GetConnectionString("MAPOSPDB");

        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        #endregion
    }
}
