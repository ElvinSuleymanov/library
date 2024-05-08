using library.Models;
using library.API;
using MediatR;

namespace library.Application;

public class GetBookQuery:IRequest<ApiResponse<GetBookResponse>>
{
    public GetBookRequest Request { get; set; }

    public GetBookQuery(GetBookRequest request)
    {
        Request = request;
    }

}
