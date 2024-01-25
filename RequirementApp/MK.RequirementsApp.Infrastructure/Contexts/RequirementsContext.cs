using MK.RequirementsApp.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;
using MK.RequirementsApp.Domain;
using System.Reflection;

namespace MK.RequirementsApp.Infrastructure.Contexts
{
    public class RequirementsContext : DbContext
    {
        public RequirementsContext(DbContextOptions<RequirementsContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Image> Images { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // configurations
            //modelBuilder.ApplyConfiguration(new ConsignerConfiguration()); // manual
            //modelBuilder.ApplyConfiguration(new BrokerConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // auto

            // seeding
            modelBuilder.Entity<Company>().Seed();
            //modelBuilder.Entity<Consigner>().Seed();
            //modelBuilder.Entity<Broker>().Seed();
            //modelBuilder.Entity<IDImage>().Seed();
            //modelBuilder.Entity<Admin>().Seed();

            // many to many relation - broker/company

            //modelBuilder.Entity("BrokerCompany").HasData(
            //    new { BrokersId = 1, CompaniesId = 1 },
            //    new { BrokersId = 2, CompaniesId = 1 },
            //    new { BrokersId = 3, CompaniesId = 1 },
            //    new { BrokersId = 4, CompaniesId = 1 },
            //    new { BrokersId = 5, CompaniesId = 1 },
            //    new { BrokersId = 6, CompaniesId = 2 },
            //    new { BrokersId = 7, CompaniesId = 2 },
            //    new { BrokersId = 8, CompaniesId = 2 },
            //    new { BrokersId = 9, CompaniesId = 2 },
            //    new { BrokersId = 10, CompaniesId = 2 }
            //);
            //modelBuilder.Entity("CompanyConfirmedBroker").HasData(
            //    new { BrokerId = 1, CompanyId = 1 },
            //    new { BrokerId = 2, CompanyId = 1 },
            //    new { BrokerId = 3, CompanyId = 1 },
            //    new { BrokerId = 4, CompanyId = 1 },
            //    new { BrokerId = 5, CompanyId = 1 },
            //    new { BrokerId = 6, CompanyId = 2 },
            //    new { BrokerId = 7, CompanyId = 2 },
            //    new { BrokerId = 8, CompanyId = 2 },
            //    new { BrokerId = 9, CompanyId = 2 },
            //    new { BrokerId = 10, CompanyId = 2 }
            //);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
