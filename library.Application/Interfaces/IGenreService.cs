using library.Application.Core;
using library.Models;

namespace library.Application;

public interface IGenreService
{
    public Task<ApiResponse<CreateGenreResponse>> Create (CreateGenreRequest request);
    public Task<ApiResponse<GetGenreResponse>> Get(GetGenreRequest request);   
}
