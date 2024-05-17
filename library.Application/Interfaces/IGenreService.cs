using library.Application.Core;
using library.Domain;
using library.Models;

namespace library.Application;

public interface IGenreService
{
    public Task<ApiResponse<CreateGenreResponse>> Create (CreateGenreRequest request);
    public Task<ApiResponse<List<GenreDto>>> Get(GetGenreRequest request);   
}
