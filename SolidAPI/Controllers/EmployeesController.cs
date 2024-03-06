using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidAPI.Dtos;
using SolidAPI.Entities;
using SolidAPI.Repositories;
using SolidAPI.UseCases;

namespace SolidAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly TicketRequestService ticketRequestService;
    private readonly IEmployeeRepository employeeRepository;
    // DI yaptık

    public EmployeesController(TicketRequestService ticketRequestService, IEmployeeRepository employeeRepository)
    {
      this.ticketRequestService = ticketRequestService;
      this.employeeRepository = employeeRepository;
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
