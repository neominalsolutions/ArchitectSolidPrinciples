using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolidAPI.Entities;

namespace SolidAPI.Data.Config
{
  public class EmployeeConfig : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      builder.HasKey(x => x.EmployeeId);
      builder.HasMany(x => x.Tickets).WithOne().HasForeignKey(x=> x.EmployeeId); // 1 to Many ilişki
      builder.Property(x => x.Department).IsRequired(false); // opsiyonel

    }
  }
}
