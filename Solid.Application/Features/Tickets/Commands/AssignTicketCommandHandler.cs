using MediatR;
using Solid.Domain.Bussiness;
using SolidAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Application.Features.Tickets.Commands
{
  // TicketRequest Service görevi görür
  // Komut işleme sınıfı
  // aradaki Mediator servis üstlenecek.
  public class AssignTicketCommandHandler : IRequestHandler<AssignTicketCommand, AssignTicketResponseDto>
  {
    private readonly TicketManager ticketManager;

    public AssignTicketCommandHandler(TicketManager ticketManager)
    {
      this.ticketManager = ticketManager;
    }
    public async Task<AssignTicketResponseDto> Handle(AssignTicketCommand request, CancellationToken cancellationToken)
    {

      // service çağırısı

      this.ticketManager.AssignTicket(request.TicketId, request.EmployeeId, request.TicketAssignmentType, request.EstimatedHour);


      return await Task.FromResult(new AssignTicketResponseDto
      {
        AssignTicketId = request.TicketId,
        CreatedAt = DateTime.Now
      });
    }
  }
}
