using SolidAPI.Repositories;

namespace SolidAPI.Bussiness
{
  public class TicketServiceFactory
  {
    // Creational Design Pattern uyguladık.
    // gelen parametreye göre hangi instance döndüreceğine karar verdik.
    // IEmployeeRepository employeeRepositor method dependecy Injection

    public static ITicketAssigment GetInstance(TicketAssigmentType ticketAssigmentType, IEmployeeRepository employeeRepository)
    {
      ITicketAssigment ticketAssigment;

      switch (ticketAssigmentType)
      {
        case TicketAssigmentType.Monthly:

          ticketAssigment= new MontlyTicketAssignmentService(employeeRepository);
          break;
        case TicketAssigmentType.Weekly:
          ticketAssigment = new WeeklyTicketAssigmentService();
          break;
        default:
          throw new Exception("Ticket Assigment Service bulunamadı");
      }

      return ticketAssigment;
    }
  }
}
