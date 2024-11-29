using CompanyAPI.Data;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Services.Entrepreneur;
using CompanyAPI.Services.Company;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Adiciona suporte às Controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEntrepreneurInterface, EntrepreneurService>();
builder.Services.AddScoped<ICompanyInterface, CompanyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); // Necessário para proteger endpoints, se aplicável

app.MapControllers(); // Mapeia as rotas das Controllers automaticamente

app.Run();
