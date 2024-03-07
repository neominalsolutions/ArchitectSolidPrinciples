using Microsoft.EntityFrameworkCore;
using Solid.Domain.Entities;
using Solid.Persistance.EF.Config;

namespace Solid.Persistance.EF.Contexts
{
    public class EFAppContext : DbContext
    {

        public EFAppContext(DbContextOptions<EFAppContext> opt) : base(opt)
        {
            // sql bağlarsak sql connection kuruluyor. program.cs dosyasında yapıyoruz.
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketAssigment> TicketAssigments { get; set; }


        // model oluşma aşamasında devreye girer.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());
      modelBuilder.ApplyConfiguration(new TicketAssigmentConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}
