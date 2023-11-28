using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services;
using Mttechne.Backend.Junior.Services.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDBContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr))
);


builder.Services.AddSwaggerGen();

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