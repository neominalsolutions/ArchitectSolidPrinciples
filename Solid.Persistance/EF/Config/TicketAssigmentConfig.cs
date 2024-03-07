using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Persistance.EF.Config
{
  internal class TicketAssigmentConfig : IEntityTypeConfiguration<TicketAssigment>
  {
    public void Configure(EntityTypeBuilder<TicketAssigment> builder)
    {
      builder.HasKey(x => x.Id);
     
    }
  }
}
