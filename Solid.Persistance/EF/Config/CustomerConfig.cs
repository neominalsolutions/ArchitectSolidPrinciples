using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solid.Domain.Entities;

namespace Solid.Persistance.EF.Config
{
  public class CustomerConfig : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder.HasKey(x => x.Id);
      builder.HasMany(x => x.Tickets).WithOne().HasForeignKey(x => x.CustomerId);
      builder.Property(x => x.CompanyName).HasColumnName("Company_Name").HasColumnType("nvarchar(50)");

    }
  }
}
