using library.Application.Core;
using library.Domain;
using library.Models;
using MediatR;

namespace library.Application;

public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, ApiResponse<List<GenreDto>>>
{   
    private IGenreService _genreService {get;set;}
    public GetGenreQueryHandler(IGenreService genreService)
    {
        _genreService = genreService;
    }
    public async Task<ApiResponse<List<GenreDto>>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
       return await _genreService.Get(request.Request);
    }
}
