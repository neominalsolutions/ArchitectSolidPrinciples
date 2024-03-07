using Solid.Application.Dtos;
using Solid.Domain.Bussiness;
using SolidAPI.Dtos;

namespace Solid.Application.Features.Tickets
{
  public class TicketRequestService 
  {
    private readonly TicketManager ticketManager;
    
    public TicketRequestService(TicketManager ticketManager) // DI
    {
      this.ticketManager = ticketManager;
    }

    public AssignTicketResponseDto AssignTicket(AssignTicketRequestDto request)
    {

      ticketManager.AssignTicket((Guid)request.TicketId, (Guid)request.EmployeeId, request.TicketAssignmentType, (int)request.EstimatedHour);


      return new AssignTicketResponseDto
      {
        AssignTicketId = (Guid)request.TicketId,
        CreatedAt = DateTime.Now
      };
    }

    public void CreateTicket()
    {

    }

  }
}
