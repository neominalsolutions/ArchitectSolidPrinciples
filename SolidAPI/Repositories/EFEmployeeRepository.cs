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

    public Employee FindById(Guid EmployeeId)
    {
      var entity = this.appContext.Employees.Find(EmployeeId);

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

    public void Save()
    {
      this.appContext.SaveChanges();
    }

    public void Update(Employee employee)
    {
      this.appContext.Employees.Update(employee);
    }
  }
}
