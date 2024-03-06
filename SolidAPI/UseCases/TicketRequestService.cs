using SolidAPI.Bussiness;
using SolidAPI.Dtos;
using SolidAPI.Repositories;

namespace SolidAPI.UseCases
{
  public class TicketRequestService // ApplicationService
  {
    // TicketManager, TicketService // Bussiness yada Domain Service
    private readonly IEmployeeRepository employeeRepository;
    // EF de olabilir, Dapper da olabilir, Adonet ile de çalışabilir.
    // DIP
    public TicketRequestService(IEmployeeRepository employeeRepository) // DI
    {
      this.employeeRepository = employeeRepository;
    }

    public AssignTicketResponseDto AssignTicket(AssignTicketRequestDto request)
    {
      // Bussiness Katmanına istek atar.

      var emp = employeeRepository.FindById((Guid)request.EmployeeId);

      if(emp is null)
      {
        throw new ArgumentException("Çalışan bulunamadı");
      }

      if(request.TicketId != null && request.EstimatedHour != null)
      {

        // hangi servisin dinamik olarak çalışacağını factory service karar vericek.
        var service = TicketServiceFactory.GetInstance((TicketAssigmentType)request.TicketAssignmentType, employeeRepository);

        service.CheckTicketAssignable((int)request.EstimatedHour, (Guid)request.EmployeeId, (Guid)request.TicketId);

        emp.AddTicket((Guid)request.TicketId, (int)request.EstimatedHour, request.TicketAssignmentType);


        // Kod değişime açık gelişime kapalı oldu, if else if gibi komutlar ile hangi servisin çalışacağına karar vermek zorunda kaldık ve aynı zamanda service instance işlemleri developer sorumluluğuna kaldı. başka bir günlük görev atama servisi gelirse kod blogu uzayıp gidecek.
        //if(request.TicketAssignmentType == (int)TicketAssigmentType.Monthly)
        //{
        //  var service = new MontlyTicketAssignmentService(employeeRepository);
        //  service.CheckTicketAssignable((int)request.EstimatedHour, (Guid)request.EmployeeId, (Guid)request.TicketId);

        //  emp.AddTicket((Guid)request.TicketId, (int)request.EstimatedHour, request.TicketAssignmentType);

        //}
        //else if(request.TicketAssignmentType == (int)TicketAssigmentType.Weekly)
        //{
        //  var service = new WeeklyTicketAssigmentService();
        //  service.CheckTicketAssignable((int)request.EstimatedHour, (Guid)request.EmployeeId, (Guid)request.TicketId);

        //  emp.AddTicket((Guid)request.TicketId, (int)request.EstimatedHour, request.TicketAssignmentType);
        //}


        //emp.AddTicket((Guid)request.TicketId, (int)request.EstimatedHour, request.TicketAssignmentType);
        // employee nesnesine yeni bir ticket eklendi
        // employee nesnesinin state değişti.

        employeeRepository.Save(); // kaydı dbye gönder.
      }


      return new AssignTicketResponseDto
      {
        AssignTicketId = (Guid)request.TicketId,
        CreatedAt = DateTime.Now
      };
    }

  }
}
