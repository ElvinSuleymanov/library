using System.Collections.ObjectModel;
using library.Domain;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Genre>().HasData(
        new Genre { Id = 1, GenreName = "Philosophy" },
        new Genre { Id = 2, GenreName = "Crime" },
        new Genre { Id = 3, GenreName = "Drama" },
        new Genre { Id = 4 , GenreName = "Horror"}
    );

    modelBuilder.Entity<Author>().HasData(new Author{Id = 1, Email = "test@gmail.com", FullName = "Dostoevsky"});

    modelBuilder.Entity<Book>().HasData(
        new Book { Id = 1, Name = "Thus Spoke Zarathustra" },
        new Book { Id = 2, Name = "Crime and Punishment" },
        new Book { Id = 3, Name = "Notes from Underground" },
        new Book { Id = 4, Name = "Last day of a Condemned Man" },
        new Book { Id = 5, Name = "Dracula" },
        new Book { Id = 6, Name = "How To Be A Stoic"}
    );

    modelBuilder.Entity<BookAuthor>().HasData(
        new BookAuthor { Id = 1, BookId = 1, AuthorId = 1 },
        new BookAuthor { Id = 2, BookId = 2, AuthorId = 1 },
        new BookAuthor { Id = 3, BookId = 3, AuthorId = 1 },
        new BookAuthor { Id = 4, BookId = 4, AuthorId = 1 },
        new BookAuthor { Id = 5, BookId = 5, AuthorId = 1 },
        new BookAuthor { Id = 6, BookId = 6, AuthorId = 1 }
    );

    modelBuilder.Entity<BookGenre>().HasData(
        new BookGenre { Id = 1, BookId = 1, GenreId = 1 },
        new BookGenre { Id = 2, BookId = 3, GenreId = 2 },
        new BookGenre { Id = 3, BookId = 3, GenreId = 1 },
        new BookGenre { Id = 4, BookId = 4, GenreId = 2 },
        new BookGenre { Id = 5, BookId = 4, GenreId = 3 },
        new BookGenre { Id = 6, BookId = 2, GenreId = 3 },
        new BookGenre { Id = 7, BookId = 2, GenreId = 2 },
        new BookGenre { Id = 8, BookId = 5, GenreId = 4 },
        new BookGenre { Id = 9, BookId = 6, GenreId = 1 }
    );
        // modelBuilder.Entity<Author>().HasData(new Author{FullName = "Friedrich Nietzsche"});
    }
    public DbSet<Book> Books{ get; set; }
    public DbSet<Genre> Genres{ get; set; } 
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users {get;set;}
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
}
