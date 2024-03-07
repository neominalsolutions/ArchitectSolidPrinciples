using MediatR;
using Solid.Application.Dtos;
using SolidAPI.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Application.Features.Tickets.Commands
{
  // TicketRequestDto
  public class AssignTicketCommand:IRequest<AssignTicketResponseDto>
  {

    [DefaultValue(40)]
    public int EstimatedHour { get; init; }

    [DefaultValue("210eddb8-fb47-4562-9613-63310ce32799")]
    public Guid EmployeeId { get; init; }

    [DefaultValue("e85b1921-8cd3-4d0b-bb64-c61922f0fde9")]
    public Guid TicketId { get; init; }

    [DefaultValue(100)]
    public int TicketAssignmentType { get; set; }

  }
}
