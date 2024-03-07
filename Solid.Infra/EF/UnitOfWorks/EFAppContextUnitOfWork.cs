using EF.Infra.Core.Contracts;
using Infra.Core.Contracts;
using Solid.Persistance.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Infra.EF.UnitOfWorks
{
  public class EFAppContextUnitOfWork : EFUnitOfWork<EFAppContext>,IUnitOfWork
  {
    public EFAppContextUnitOfWork(EFAppContext context) : base(context)
    {
    }
  }
}
