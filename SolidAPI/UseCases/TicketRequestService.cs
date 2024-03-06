using SolidAPI.Bussiness;
using SolidAPI.Dtos;
using SolidAPI.Repositories;

namespace SolidAPI.UseCases
{
  public class TicketRequestService // ApplicationService
  {
    // TicketManager, TicketService // Bussiness yada Domain Service
    //private readonly IEmployeeRepository employeeRepository;
    // EF de olabilir, Dapper da olabilir, Adonet ile de çalışabilir.
    private readonly TicketManager ticketManager;
    // DIP
    //public TicketRequestService(IEmployeeRepository employeeRepository) // DI
    //{
    //  this.employeeRepository = employeeRepository;
  
    //}

    public TicketRequestService(TicketManager ticketManager) // DI
    {
      this.ticketManager = ticketManager;
    }

    public AssignTicketResponseDto AssignTicket(AssignTicketRequestDto request)
    {
      // Bussiness Katmanına istek atar.


      #region OpenCloseUygulamadanOncekiHali

      /*
       * MontlyTicketAssignmentService içindeki kodları bu katmana if else ile yazılması lazım.
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


      */

      #endregion

      #region FactoryPattern

      /* 

      var emp = employeeRepository.FindById((Guid)request.EmployeeId);

      if(emp is null)
      {
        throw new ArgumentException("Çalışan bulunamadı");
      }

      if (request.TicketId != null && request.EstimatedHour != null)
      {

        // hangi servisin dinamik olarak çalışacağını factory service karar vericek.
        var service = TicketServiceFactory.GetInstance((TicketAssigmentType)request.TicketAssignmentType, employeeRepository);

        service.CheckTicketAssignable((int)request.EstimatedHour, (Guid)request.EmployeeId, (Guid)request.TicketId);

        emp.AddTicket((Guid)request.TicketId, (int)request.EstimatedHour, request.TicketAssignmentType);


        //emp.AddTicket((Guid)request.TicketId, (int)request.EstimatedHour, request.TicketAssignmentType);
        // employee nesnesine yeni bir ticket eklendi
        // employee nesnesinin state değişti.

        employeeRepository.Save(); // kaydı dbye gönder.
      }
      */

      #endregion


      #region StrategyPattern

      // Parametreye bağlı bir davranış gösteriyor
      // bu sebeple Ticket Manager service kendi için iş sürecini yönetiminden sorumlu manager sınıf olmuş oluyor.
      // Bussiness Service
      ticketManager.AssignTicket((Guid)request.TicketId, (Guid)request.EmployeeId, request.TicketAssignmentType, (int)request.EstimatedHour);

      #endregion


      return new AssignTicketResponseDto
      {
        AssignTicketId = (Guid)request.TicketId,
        CreatedAt = DateTime.Now
      };
    }

  }
}
