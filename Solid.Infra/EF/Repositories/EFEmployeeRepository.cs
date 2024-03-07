using EF.Infra.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Solid.Domain.Entities;
using Solid.Domain.Repositories;
using Solid.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Infra.EF.Repositories
{
  public class EFEmployeeRepository : EFRepository<AppContext, Employee, Guid>, IEmployeeRepo
  {
    public EFEmployeeRepository(AppContext db) : base(db)
    {
    }

    public override IEnumerable<Employee> Find(Expression<Func<Employee, bool>> lamda)
    {
      return  db.Employees.AsNoTracking().Include(x => x.Tickets).Where(lamda).ToList();
    }
  }
}
