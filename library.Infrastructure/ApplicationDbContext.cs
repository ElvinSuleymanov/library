using library.Domain;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books{ get; set; }
    public DbSet<Genre> Genres{ get; set; } 
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users {get;set;}
}
