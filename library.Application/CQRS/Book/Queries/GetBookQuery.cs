using library;
using library.Application.Core;
using library.Models;
using MediatR;


namespace library.Application.CQRS.Book.Queries;

public class GetBookQuery : IRequest<ApiResponse<GetBookResponse>>
{
    public GetBookRequest Request { get; set; }

    public GetBookQuery(GetBookRequest request)
    {
        Request = request;
    }

}
