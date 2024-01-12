using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mttechne.Backend.Junior.Services;
using Mttechne.Backend.Junior.Services.Services.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(y =>
    {
        y.AllowAnyMethod();
        y.AllowAnyOrigin();
        y.AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

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

app.UseCors();

app.MapControllers();

app.Run();