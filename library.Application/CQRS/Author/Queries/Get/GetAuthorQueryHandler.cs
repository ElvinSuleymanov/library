using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, ApiResponse<List<GetAuthorResponse>>>
{
    private IAuthorService _AuthorService { get; set; }
    public GetAuthorQueryHandler(IAuthorService service)
    {
        _AuthorService = service;
    }
    public async Task<ApiResponse<List<GetAuthorResponse>>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        return await _AuthorService.Get(request.Request);
    }
}
