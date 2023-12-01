using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services;
using Mttechne.Backend.Junior.Services.Data.Context;
using Mttechne.Backend.Junior.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MttechneDb");
builder.Services.AddDbContext<MttechneDbContext>(o => o.UseSqlite(connectionString, b => b.MigrationsAssembly("Mttechne.Backend.Junior.Interface")));

DependencyInjection.RegisterBindings(builder.Services);

var app = builder.Build();

var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetService<IDbInitializer>();
service.Initialize();

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