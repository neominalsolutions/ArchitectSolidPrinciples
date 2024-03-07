using Solid.Domain.Entities;
using Solid.Domain.Services;

namespace SolidAPI.Repositories
{
  public class AdoNetEmployeeRepository : IEmployeeRepository
  {
    public void Create(Employee employee)
    {
      throw new NotImplementedException();
    }

    public void Delete(Guid employeeId)
    {
      throw new NotImplementedException();
    }

    public Employee FindById(Guid EmployeeId)
    {
      return new Employee("Asli", "Can");
    }

    public Employee FindByWithTickets(Guid EmployeeId)
    {
      throw new NotImplementedException();
    }

    public void Save(Employee? employee)
    {
      throw new NotImplementedException();
    }

    public void Update(Employee employee)
    {
      throw new NotImplementedException();
    }
  }
}
