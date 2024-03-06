using SolidAPI.Entities;

namespace SolidAPI.Repositories
{
  public interface IEmployeeRepository
  {
    public Employee FindById(Guid EmployeeId);
    public void Update(Employee employee);

    public void Save();
  }
}
