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
    public async Task<ApiResponse<GetTopGenreResponse>> Get(GetTopGenreRequest request)
    {
        var result = await _context.Genres.Include(c => c.Books).ThenInclude(c => c.Genre).OrderDescending().Take((int)request.Count).ToListAsync();
        GetTopGenreResponse res = new GetTopGenreResponse {Genres = result};
        return ApiResponse<GetTopGenreResponse>.Success(res);
    }
}
