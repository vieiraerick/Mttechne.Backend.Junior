using Mttechne.Backend.Junior.Services;
using Mttechne.Backend.Junior.Services.Context;
using Mttechne.Backend.Junior.Services.Interface;
using Mttechne.Backend.Junior.Services.Repositories;
using Mttechne.Backend.Junior.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
//DependencyInjection.RegisterBindings(builder.Services);

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