using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.CrossCutting;
using Mttechne.Backend.Junior.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var services = builder.Services;
var config = builder.Configuration;


services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("Padrao"));
});

DependencyInjection.RegisterBindings(builder.Services);

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