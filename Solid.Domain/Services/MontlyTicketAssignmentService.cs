

using Solid.Domain.Services;

namespace Solid.Domain.Bussiness
{
  public class MontlyTicketAssignmentService : ITicketAssigment
  {
    // ne kadarlık bir ticket assign edilmiş bunu almam lazım
    private readonly IEmployeeRepository employeeRepository;

    public MontlyTicketAssignmentService(IEmployeeRepository employeeRepository)
    {
      this.employeeRepository = employeeRepository;
    }

    public void CheckTicketAssignable(int estimatedHour, Guid employeeId, Guid ticketId)
    {

      var monthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);

      int DaysInMonthCount = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

      var monthEndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DaysInMonthCount);

      var emp = employeeRepository.FindByWithTickets(employeeId);
      var monthlyTicketHours = emp.Tickets.Where(x => x.AssignedAt.Value.Date >= monthStartDate.Date && x.AssignedAt.Value.Date <= monthEndDate.Date).Sum(x => x.EstimatedHour);

      if(estimatedHour + monthlyTicketHours > 160)
      {
        throw new Exception("Aylık görev atama kotası aşıldı");
      }

      //emp.AddTicket(ticketId, estimatedHour, ticketAssigmentType);
      // eğer normal koşullar altında ise atamayı yap.
      // emp yeni bir ticket eklendi.

    }
  }
}
