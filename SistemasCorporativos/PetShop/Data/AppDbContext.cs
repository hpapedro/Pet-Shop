using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionarios { get; set; }
}

