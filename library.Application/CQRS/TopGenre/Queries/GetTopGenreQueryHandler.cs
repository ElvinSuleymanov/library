using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class GetTopGenreQueryHandler : IRequestHandler<GetTopGenreQuery, ApiResponse<GetTopGenreResponse>>
{
    public Task<ApiResponse<GetTopGenreResponse>> Handle(GetTopGenreQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
