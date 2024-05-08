using library.API;
using library.Models;
using MediatR;

namespace library.Application;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, ApiResponse<GetBookResponse>>
{
    public Task<ApiResponse<GetBookResponse>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
