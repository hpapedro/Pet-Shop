using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShop.Models;

namespace PetShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Produto> Produtos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roleConverter = new EnumToStringConverter<Role>();
            modelBuilder.Entity<Funcionario>().Property(f => f.Cargo).HasConversion(roleConverter);

            base.OnModelCreating(modelBuilder);
        }
}

