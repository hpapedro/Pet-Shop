using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Repositories;
using PetShop.Repository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run();