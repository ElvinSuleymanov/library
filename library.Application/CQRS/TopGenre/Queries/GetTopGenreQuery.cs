using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class GetTopGenreQuery:IRequest<ApiResponse<GetTopGenreResponse>>
{
    public GetTopGenreRequest Request { get; set; }
    public GetTopGenreQuery(GetTopGenreRequest request)
    {
        Request = request;
    }
}
