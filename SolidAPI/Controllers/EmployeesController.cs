using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidAPI.Dtos;
using SolidAPI.UseCases;

namespace SolidAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly TicketRequestService ticketRequestService;
    // DI yaptık

    public EmployeesController(TicketRequestService ticketRequestService)
    {
      this.ticketRequestService = ticketRequestService;
    }


    [HttpPost]
    public IActionResult AssignTicket([FromBody] AssignTicketRequestDto request)
    {
      var response = this.ticketRequestService.AssignTicket(request);

      return Ok(response);
    }

  }
}
