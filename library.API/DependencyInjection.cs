using System.Reflection;
using library.Application;
using library.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace library.API;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)  {
        services.AddDbContext<ApplicationDbContext>(ctx => {
            ctx.UseMySql("Server=localhost;Uid=root;Pwd=elvin;Database=libraryDB;", ServerVersion.AutoDetect("Server=localhost;Uid=root;Pwd=elvin;Database=libraryDB;"));
        });
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IGenreService, GenreService>();
        services.AddTransient<ITopGenreService, TopGenreService>(); 
        services.AddTransient<IAuthorService, AuthorService>();
        return services;
    }
}
