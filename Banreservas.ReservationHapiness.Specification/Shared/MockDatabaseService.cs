//using MAP.OSP.Application.Interfaces;
//using MAP.OSP.Domain.Entities.Customers;
//using MAP.OSP.Domain.Entities.Employees;
//using MAP.OSP.Domain.Entities.Products;
//using MAP.OSP.Domain.Entities.Sales;
//using MAP.OSP.Persistence.Customers;
//using MAP.OSP.Persistence.Employees;
//using MAP.OSP.Persistence.Products;
//using MAP.OSP.Persistence.Sales;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MAP.OSP.Specification.Shared
//{
//    public class MockMAPOSPDbContext : DbContext, IMAPOSPDbContext
//    {
//        public MockMAPOSPDbContext(DbContextOptions options) : base(options)
//        {
//            Database.EnsureDeleted();
//            Database.EnsureCreated();
//        }

//        public DbSet<Customer> Customers { get; set; }

//        public DbSet<Employee> Employees { get; set; }

//        public DbSet<Product> Products { get; set; }

//        public DbSet<Sale> Sales { get; set; }

//        public void Save()
//        {
//            this.SaveChanges();
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseInMemoryDatabase(databaseName: "MAP.OSPInMemory");
//        }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            base.OnModelCreating(builder);

//            new CustomerConfiguration().Configure(builder.Entity<Customer>());
//            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
//            new ProductConfiguration().Configure(builder.Entity<Product>());
//            new SaleConfiguration().Configure(builder.Entity<Sale>());
//        }
//    }
//}
