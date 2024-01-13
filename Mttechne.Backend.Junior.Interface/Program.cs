using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services;
using Mttechne.Backend.Junior.Services.Configuration;
using Mttechne.Backend.Junior.Services.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuracao = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(),"appsettings.json"), optional: false)
            .Build();

string? connectionString = configuracao.GetSection("ConnectionString").GetSection("DBConnectionString").Value;
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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