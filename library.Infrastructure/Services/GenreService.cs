using library.Application;
using library.Application.Core;
using library.Domain;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure;

public class GenreService : IGenreService
{
    private ApplicationDbContext _context { get; set; }
    public GenreService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ApiResponse<CreateGenreResponse>> Create(CreateGenreRequest request)
    {
        Genre genre = new Genre { GenreName = request.Name };
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();
        CreateGenreResponse res = new CreateGenreResponse { };
        return ApiResponse<CreateGenreResponse>.Success(res);
    }
    public async Task<ApiResponse<List<GenreDto>>> Get(GetGenreRequest request)
    {

        bool isRequestNull = request.GenreId is null;
        bool isTopGenreNull = request.TopGenre is null;

        List<GenreDto> Genres =
        _context.Genres.Where(x => isRequestNull || request.GenreId == x.Id)
        .Include(x => x.Books)
        .ThenInclude(x => x.Book)
        .OrderByDescending(x => x.Books.Count)
        .Take((int)request.TopGenre)
        .Select(x => new GenreDto
        {
            Id = x.Id,
            GenreName = x.GenreName,
            BookCount = x.Books.Count,
            Books = x.Books.Select(x => new BookDto { Name = x.Book.Name, Id = x.Book.Id }).ToList()
        }).ToList();

        return ApiResponse<List<GenreDto>>.Success(Genres);
    }



}
