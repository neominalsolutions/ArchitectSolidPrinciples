using Microsoft.EntityFrameworkCore;
using Solid.Domain.Entities;
using SolidAPI.Data.Config;


namespace SolidAPI.Data
{
  public class AppContext:DbContext
  {

    public AppContext(DbContextOptions<AppContext> opt):base(opt)
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


      base.OnModelCreating(modelBuilder);
    }
  }
}
