using Infra.Core;
using Solid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Domain.Repositories
{
  public interface ITicketAssigmentRepo: ICrudRepository<TicketAssigment, Guid>
  {
  }
}
