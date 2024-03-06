using Microsoft.EntityFrameworkCore;
using SolidAPI.Bussiness;
using SolidAPI.Repositories;
using SolidAPI.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
