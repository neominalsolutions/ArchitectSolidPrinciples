using SolidAPI.Entities;

namespace SolidAPI.Repositories
{
  public class AdoNetEmployeeRepository : IEmployeeRepository
  {
    public Employee FindById(Guid EmployeeId)
    {
      return new Employee("Asli", "Can");
    }

    public void Save()
    {
      throw new NotImplementedException();
    }

    public void Update(Employee employee)
    {
      throw new NotImplementedException();
    }
  }
}
