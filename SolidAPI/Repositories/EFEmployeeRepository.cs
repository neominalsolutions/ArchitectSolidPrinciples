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

    public Employee FindById(Guid EmployeeId)
    {
      var entity = this.appContext.Employees.Include(x=> x.Tickets).FirstOrDefault(x=> x.EmployeeId == EmployeeId);




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


      try
      {
        appContext.SaveChanges();

       
      }
      catch (Exception ex)
      {

        throw ex;
      }
    
    }

    public void Update(Employee employee)
    {
      //var emp = this.appContext.Employees.Find(employee.EmployeeId);
      employee.Department = "IT";

      //foreach (var item in employee.Tickets)
      //{
      //  emp.Tickets.Add(item);
      //}


      //var state =  this.appContext.Entry(employee).State;

      ////emp.Department = employee.Department;
      //this.appContext.Entry(emp).State = EntityState.Modified;

      this.appContext.Update(employee);


      this.appContext.SaveChanges();
    }
  }
}
