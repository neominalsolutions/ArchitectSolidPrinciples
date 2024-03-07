

using Infra.Core.Contracts;
using Solid.Domain.Repositories;
using Solid.Domain.Services;

namespace Solid.Domain.Bussiness
{
  public class TicketManager // Strategy Design Pattern
  {
    private readonly IEmployeeRepo employeeRepository;
    private readonly IUnitOfWork unitOfWork;

    public TicketManager(IEmployeeRepo employeeRepository, IUnitOfWork unitOfWork)
    {
      this.employeeRepository = employeeRepository;
      this.unitOfWork = unitOfWork;
    }

    public void AssignTicket(Guid ticketId,Guid employeeId, int ticketAssigmentType, int estimatedHour)
    {


      if(ticketAssigmentType == (int)TicketAssigmentType.Monthly)
      {
        var service = new MontlyTicketAssignmentService(employeeRepository);
        service.CheckTicketAssignable(estimatedHour, employeeId, ticketId);

        var emp = employeeRepository.FindById(employeeId);
        
        if(emp is not null)
        {
          emp.AddTicket(ticketId, estimatedHour, ticketAssigmentType);
          employeeRepository.Update(emp);
          this.unitOfWork.Save();
          // veri tabanına yansırma işlemleri UnitOfWork üzerinden yapılsın.
        } 
        else
        {
          throw new Exception("Çalışan bulunamadı");
        }

      }
      else if(ticketAssigmentType == (int)TicketAssigmentType.Weekly)
      {
        // ilgili işlemler yapılır.
      }
    }

  }
}
