using Microsoft.EntityFrameworkCore;

namespace back_app.Models;

public class AppDataContext : DbContext
{
    public DbSet<Livro>? Livros {get; set;}
    public DbSet<Usuario>? Usuarios {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Bancozao.db");
    }
}