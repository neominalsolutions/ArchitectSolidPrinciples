using Microsoft.EntityFrameworkCore;
using SolidAPI.Data;
using SolidAPI.Entities;

namespace SolidAPI.Repositories
{
  public class EFEmployeeRepository : IEmployeeRepository
  {
    private readonly Data.AppContext appContext;

    public EFEmployeeRepository(Data.AppContext appContext)
    {
      this.appContext = appContext;
    }

    public Employee FindByWithTickets(Guid EmployeeId)
    {
      var entity = this.appContext.Employees.AsNoTracking().Include(x => x.Tickets).FirstOrDefault(x => x.EmployeeId == EmployeeId);


      if (entity is null)
      {
        throw new Exception("Entity NotFound");
      }

      return entity;
    }

    public Employee FindById(Guid EmployeeId)
    {
      var entity = this.appContext.Employees.FirstOrDefault(x=> x.EmployeeId == EmployeeId);


      if(entity is null)
      {
        throw new Exception("Entity NotFound");
      }

      return entity;
    }

    public void Create(Employee employee)
    {
      this.appContext.Employees.Add(employee);
    }

    public void Delete(Guid employeeId)
    {
      var entity = FindById(employeeId);

      if (entity is not null)
      {
        this.appContext.Employees.Remove(entity);
      }
    }

    public void Save(Employee? employee)
    {


      try
      {

        if(employee is not null && employee.Tickets.Count > 0)
        {
          this.appContext.TicketAssigments.AddRangeAsync(employee.Tickets);
        }

       
        this.appContext.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        throw ex;
      }
    
    }

    public void Update(Employee employee)
    {
      this.appContext.Employees.Update(employee);
    }
  }
}
