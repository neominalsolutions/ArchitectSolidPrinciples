using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solid.Domain.Entities;

namespace Solid.Persistance.EF.Config
{
  public class EmployeeConfig : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      builder.HasKey(x => x.Id);
      builder.HasMany(x => x.Tickets).WithOne().HasForeignKey(x=> x.EmployeeId); // 1 to Many ilişki
      builder.Property(x => x.Department).IsRequired(false); // opsiyonel

    }
  }
}
