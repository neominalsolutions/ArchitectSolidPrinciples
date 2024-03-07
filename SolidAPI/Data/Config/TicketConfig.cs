using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solid.Domain.Entities;


namespace SolidAPI.Data.Config
{
  public class TicketConfig : IEntityTypeConfiguration<Ticket>
  {
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
      builder.HasKey(x => x.TicketId);
      builder.Property(x => x.Title).IsRequired();
      builder.Property(x => x.Description).IsRequired(false).HasMaxLength(200);
    }
  }
}
