using library.Application.Core;
using library.Models;

namespace library.Application;

public interface ITopGenreService
{
    public Task<ApiResponse<List<GetTopGenreResponse>>> Get(GetTopGenreRequest request);
}
