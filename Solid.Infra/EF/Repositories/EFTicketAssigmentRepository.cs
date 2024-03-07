using EF.Infra.Core.Contracts;
using Solid.Domain.Entities;
using Solid.Domain.Repositories;
using Solid.Persistance.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Infra.EF.Repositories
{
  public class EFTicketAssigmentRepository : EFRepository<EFAppContext, TicketAssigment, Guid>, ITicketAssigmentRepo
  {
    public EFTicketAssigmentRepository(EFAppContext db) : base(db)
    {
    }
  }
}
