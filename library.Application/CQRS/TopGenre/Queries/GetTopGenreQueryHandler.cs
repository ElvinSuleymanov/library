using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class GetTopGenreQueryHandler : IRequestHandler<GetTopGenreQuery, ApiResponse<List<GetTopGenreResponse>>>

{
   private ITopGenreService _TopGenreService { get; set;}
   public GetTopGenreQueryHandler(ITopGenreService TopGenreService)
   {
    _TopGenreService = TopGenreService;
   }
    public async Task<ApiResponse<List<GetTopGenreResponse>>> Handle(GetTopGenreQuery request, CancellationToken cancellationToken)
    {
       return await _TopGenreService.Get(request.Request);
    }
}
