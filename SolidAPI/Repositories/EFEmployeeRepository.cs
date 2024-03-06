using SolidAPI.Entities;

namespace SolidAPI.Repositories
{
  public class EFEmployeeRepository : IEmployeeRepository
  {
    public Employee FindById(Guid EmployeeId)
    {
      return new Employee("Ali", "Can");
    }

    public void Save()
    {
      
    }

    public void Update(Employee employee)
    {
      
    }
  }
}
