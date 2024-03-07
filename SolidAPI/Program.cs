using FluentValidation;
using FluentValidation.AspNetCore;
using Infra.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Solid.Application.Features.Tickets;
using Solid.Application.Features.Tickets.Commands;
using Solid.Domain.Bussiness;
using Solid.Domain.Repositories;
using Solid.Infra.EF.Repositories;
using Solid.Infra.EF.UnitOfWorks;
using Solid.Persistance.EF.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Her katman kendini IoC register ediyor.

#region ApplicationLayer

// Application Layer
// Mediator i�in bir servis ekleriz.
// Reflection ile Application katman�ndaki bir s�n�f� g�sterek orada tan�mlanm�� t�m handlerlar� Ioc y�kledik.
builder.Services.AddMediatR(config =>
{
  // AssignTicketHandler bulundu�u assembly load et.
  config.RegisterServicesFromAssemblyContaining<AssignTicketCommandHandler>();
});

// Fluent Validation Registeratio
builder.Services.AddValidatorsFromAssemblyContaining<AssignTicketValidator>();
// Net core uygulamalar�nda otomatik validation y�ntemi model state binding ger�ekle�ti�inden bu default davran��� fluent validation k�t�phanesine b�rak�yoruz.
builder.Services.AddFluentValidationAutoValidation();
// 400 validation error direk pipeline �zerinden hata f�rlatacak.

// IoC registeration

#endregion

#region InfraLayer

// Infra Layer
builder.Services.AddScoped<IEmployeeRepo, Solid.Infra.EF.Repositories.EFEmployeeRepository>();
builder.Services.AddScoped<ITicketAssigmentRepo, EFTicketAssigmentRepository>();

builder.Services.AddScoped<IUnitOfWork, EFAppContextUnitOfWork>();

#endregion

#region DomainLayer
// Domain Layer
builder.Services.AddScoped<TicketManager>();

#endregion

#region PersistanceLayer
// Persistance Layer
builder.Services.AddDbContext<EFAppContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("TicketConn"));
});

#endregion



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
