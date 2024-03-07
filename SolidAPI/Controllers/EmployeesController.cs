using Infra.Core.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solid.Application.Dtos;
using Solid.Application.Features.Tickets;
using Solid.Application.Features.Tickets.Commands;
using Solid.Domain.Entities;
using Solid.Domain.Repositories;
using Solid.Domain.Services;

namespace SolidAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    
    private readonly IEmployeeRepo employeeRepository;
    private readonly IMediator mediator;
    private readonly IUnitOfWork unitOfWork;
    // DI yaptık

    public EmployeesController(IEmployeeRepo employeeRepository, IMediator mediator, IUnitOfWork unitOfWork)
    {
      this.employeeRepository = employeeRepository;
      this.mediator = mediator;
      this.unitOfWork = unitOfWork;
    }

    [HttpPost("assingTicket")]
    public async Task<IActionResult> AssignTicketAsync([FromBody] AssignTicketCommand request)
    {

      var response = await this.mediator.Send(request);

      return Ok(response);
    }


    [HttpPost("create")]
    public IActionResult Create()
    {


      // 1.işlem
      var employee = new Employee("Yunus3", "Kaan");
      this.employeeRepository.Create(employee);

      //2.işlem
      var employee1 = new Employee("Yunus4", "Kaan1");
      this.employeeRepository.Create(employee1);

     
      // 3.işlem
      employee.AddTicket(new Guid("e85b1921-8cd3-4d0b-bb64-c61922f0fde9"), 12, 100);

      this.unitOfWork.AutoSave(); // yukarıdaki tüm işlemleri tek bir transaction içinde yapacağız.


      return Ok();

    }

  }
}
