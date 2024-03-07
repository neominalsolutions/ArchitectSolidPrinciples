

using Infra.Core.Contracts;
using Solid.Domain.Entities;
using Solid.Domain.Repositories;
using Solid.Domain.Services;

namespace Solid.Domain.Bussiness
{
  public class TicketManager // Strategy Design Pattern
  {
    private readonly IEmployeeRepo employeeRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly ITicketAssigmentRepo ticketAssigmentRepo;

    public TicketManager(IEmployeeRepo employeeRepository, IUnitOfWork unitOfWork, ITicketAssigmentRepo ticketAssigmentRepo)
    {
      this.employeeRepository = employeeRepository;
      this.unitOfWork = unitOfWork;
      this.ticketAssigmentRepo = ticketAssigmentRepo;
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

          var ticketAssigment = new TicketAssigment(ticketId, employeeId,estimatedHour, ticketAssigmentType);
          this.ticketAssigmentRepo.Create(ticketAssigment);

          // emp.AddTicket(ticketId, estimatedHour, ticketAssigmentType);
          // employeeRepository.Update(emp);
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
