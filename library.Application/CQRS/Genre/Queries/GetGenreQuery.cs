using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class GetGenreQuery:IRequest<ApiResponse<GetGenreResponse>>
{
    public GetGenreRequest Request {get;set;}
    public GetGenreQuery(GetGenreRequest request)
    {
            Request = request;
    }
}