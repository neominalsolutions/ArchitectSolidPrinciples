using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solid.Domain.Entities;

namespace SolidAPI.Data.Config
{
  public class CustomerConfig : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder.HasKey(x => x.CustomerId);
      builder.Property(x => x.CompanyName).HasColumnName("Company_Name").HasColumnType("nvarchar(50)");

    }
  }
}
