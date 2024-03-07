using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Solid.Application.Features.Tickets;
using Solid.Application.Features.Tickets.Commands;
using Solid.Domain.Bussiness;
using Solid.Domain.Services;
using SolidAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mediator i�in bir servis ekleriz.
// Reflection ile Application katman�ndaki bir s�n�f� g�sterek orada tan�mlanm�� t�m handlerlar� Ioc y�kledik.
builder.Services.AddMediatR(config =>
{
  // AssignTicketHandler bulundu�u assembly load et.
  config.RegisterServicesFromAssemblyContaining<AssignTicketCommandHandler>();
});

// Fluent Validation Registeration

builder.Services.AddValidatorsFromAssemblyContaining<AssignTicketValidator>();
// Net core uygulamalar�nda otomatik validation y�ntemi model state binding ger�ekle�ti�inden bu default davran��� fluent validation k�t�phanesine b�rak�yoruz.
builder.Services.AddFluentValidationAutoValidation();
// 400 validation error direk pipeline �zerinden hata f�rlatacak.

// IoC registeration
builder.Services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddScoped<TicketRequestService>();
builder.Services.AddScoped<TicketManager>();


builder.Services.AddDbContext<SolidAPI.Data.AppContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("TicketConn"));
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
