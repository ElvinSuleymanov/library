using library.Application;
using library.Application.Core;
using library.Domain;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure;

public class GenreService:IGenreService
{
    private ApplicationDbContext _context {get;set;}
    public GenreService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ApiResponse<CreateGenreResponse>> Create(CreateGenreRequest request) {
        Genre genre = new Genre{GenreName = request.Name};
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();
        CreateGenreResponse res = new CreateGenreResponse {};
        return ApiResponse<CreateGenreResponse>.Success(res);
    }
     public async Task<ApiResponse<GetGenreResponse>> Get(GetGenreRequest request) {
        bool condition = request.GenreId != null;
        List<Genre> genre = await _context.Genres.Where(x => condition ? request.GenreId == x.Id : true).ToListAsync();
        GetGenreResponse res = new GetGenreResponse {Genres = genre};
        return ApiResponse<GetGenreResponse>.Success(res);
    }
    
   

}
