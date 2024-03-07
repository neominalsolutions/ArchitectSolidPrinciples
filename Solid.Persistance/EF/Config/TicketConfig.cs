using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solid.Domain.Entities;


namespace Solid.Persistance.EF.Config
{
  public class TicketConfig : IEntityTypeConfiguration<Ticket>
  {
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Title).IsRequired();
      builder.HasMany(x => x.TicketAssigments).WithOne().HasForeignKey(x => x.TicketId);
      builder.Property(x => x.Description).IsRequired(false).HasMaxLength(200);
    }
  }
}
