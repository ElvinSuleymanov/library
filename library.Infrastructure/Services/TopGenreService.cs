using library.Application;
using library.Application.Core;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure;

public class TopGenreService : ITopGenreService
{
    public ApplicationDbContext _context {get;set;}
    public TopGenreService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ApiResponse<List<GetTopGenreResponse>>> Get(GetTopGenreRequest request)
    {
        var result = await _context.Genres.OrderByDescending(x => x.Books.Count()).Take((int)request.Count).Select(el => new GetTopGenreResponse{Genre = el, BookCount = el.Books.Count()}).ToListAsync();
        return ApiResponse<List<GetTopGenreResponse>>.Success(result);
    } 
}
