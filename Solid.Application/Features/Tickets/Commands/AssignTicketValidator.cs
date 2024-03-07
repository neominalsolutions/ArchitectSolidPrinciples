using FluentValidation;
using Solid.Domain.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Application.Features.Tickets.Commands
{
  // AssignTicketValidasyonu için kullanacağız.
  public class AssignTicketValidator:AbstractValidator<AssignTicketCommand>
  {
    public AssignTicketValidator()
    {
      RuleFor(x => x.EstimatedHour).GreaterThanOrEqualTo(1).WithMessage("Görev en az 1 saatlik girilebilir");
      RuleFor(x => x.EstimatedHour).LessThanOrEqualTo(40).WithMessage("Görev en fazla 40 saatlik girilebilir");

      RuleFor(x => x.EmployeeId).NotEmpty().NotNull().WithMessage("Çalışan seçimi yapınız");

      RuleFor(x => x.TicketId).NotEmpty().NotNull().WithMessage("Görev seçimi yapınız");

      RuleFor(x => x.TicketAssignmentType).Must(CheckTicketAssignmentType).WithMessage("100 ve 120 kodlarını kullanamalıyız");

    }

    private bool CheckTicketAssignmentType(int ticketAssigmentType)
    {
      var values = ((TicketAssigmentType[])Enum.GetValues(typeof(TicketAssigmentType))).Select(x=> x).ToList();

      return values.Any(x => (int)x == ticketAssigmentType);
    }
  }
}
