using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solid.Application.Dtos;
using Solid.Application.Features.Tickets;
using Solid.Application.Features.Tickets.Commands;
using Solid.Domain.Entities;
using Solid.Domain.Services;

namespace SolidAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly TicketRequestService ticketRequestService;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IMediator mediator;
    // DI yaptık

    public EmployeesController(TicketRequestService ticketRequestService, IEmployeeRepository employeeRepository, IMediator mediator)
    {
      this.ticketRequestService = ticketRequestService;
      this.employeeRepository = employeeRepository;
      this.mediator = mediator;
    }

    [HttpPost("assignTicketHandler")]
    public async Task<IActionResult> AssignTicketAsync([FromBody] AssignTicketCommand request)
    {

      var response = await this.mediator.Send(request);

      return Ok(response);
    }

    [HttpPost("assingTicket")]
    public IActionResult AssignTicket([FromBody] AssignTicketRequestDto request)
    {
      // use-case
      var response = this.ticketRequestService.AssignTicket(request);

      return Ok(response);
    }


    [HttpPost("create")]
    public IActionResult Create()
    {


      var employee = new Employee("Yunus", "Kaan");
      this.employeeRepository.Create(employee);

      employee.AddTicket(new Guid("e85b1921-8cd3-4d0b-bb64-c61922f0fde9"), 10, 100);

      this.employeeRepository.Save(employee);

      return Ok();

    }

  }
}
