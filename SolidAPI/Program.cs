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
// Mediator için bir servis ekleriz.
// Reflection ile Application katmanýndaki bir sýnýfý gösterek orada tanýmlanmýþ tüm handlerlarý Ioc yükledik.
builder.Services.AddMediatR(config =>
{
  // AssignTicketHandler bulunduðu assembly load et.
  config.RegisterServicesFromAssemblyContaining<AssignTicketCommandHandler>();
});

// Fluent Validation Registeratio
builder.Services.AddValidatorsFromAssemblyContaining<AssignTicketValidator>();
// Net core uygulamalarýnda otomatik validation yöntemi model state binding gerçekleþtiðinden bu default davranýþý fluent validation kütüphanesine býrakýyoruz.
builder.Services.AddFluentValidationAutoValidation();
// 400 validation error direk pipeline üzerinden hata fýrlatacak.

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
