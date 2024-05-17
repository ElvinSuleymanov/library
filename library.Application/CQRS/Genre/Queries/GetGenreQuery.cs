using library.Application.Core;
using library.Domain;
using library.Models;
using MediatR;

namespace library.Application;

public class GetGenreQuery:IRequest<ApiResponse<List<GenreDto>>>
{
    public GetGenreRequest Request {get;set;}
    public GetGenreQuery(GetGenreRequest request)
    {
            Request = request;
    }
}