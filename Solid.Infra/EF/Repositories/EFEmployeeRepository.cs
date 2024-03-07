using EF.Infra.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Solid.Domain.Entities;
using Solid.Domain.Repositories;
using Solid.Persistance.EF.Contexts;
using System.Linq.Expressions;

namespace Solid.Infra.EF.Repositories
{
    public class EFEmployeeRepository : EFRepository<EFAppContext, Employee, Guid>, IEmployeeRepo
  {
    public EFEmployeeRepository(EFAppContext db) : base(db)
    {
    }

    public override void Update(Employee entity)
    {
      base.Update(entity);
    }

    public override Employee FindById(Guid Id)
    {
      return db.Employees.Include(x => x.Tickets).FirstOrDefault(x => x.Id == Id);

      //return base.FindById(Id);
    }

    public override IEnumerable<Employee> Find(Expression<Func<Employee, bool>> lamda)
    {
      return  db.Employees.AsNoTracking().Include(x => x.Tickets).Where(lamda).ToList();
    }
  }
}
