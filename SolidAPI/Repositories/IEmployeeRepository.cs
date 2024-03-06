using SolidAPI.Entities;

namespace SolidAPI.Repositories
{
  public interface IEmployeeRepository
  {
    public Employee FindById(Guid EmployeeId);
    public void Update(Employee employee);

    public Employee FindByWithTickets(Guid EmployeeId);

    public void Create(Employee employee);

    public void Delete(Guid employeeId);

    public void Save(Employee? employee);
  }
}
