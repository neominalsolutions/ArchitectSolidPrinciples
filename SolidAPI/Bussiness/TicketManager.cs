using SolidAPI.Repositories;

namespace SolidAPI.Bussiness
{
  public class TicketManager // Strategy Design Pattern
  {
    private readonly IEmployeeRepository employeeRepository;

    public TicketManager(IEmployeeRepository employeeRepository)
    {
      this.employeeRepository = employeeRepository;
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
          employeeRepository.Save();
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
