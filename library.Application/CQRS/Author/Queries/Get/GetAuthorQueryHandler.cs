using library.Application.Core;
using library.Domain;
using library.Models;
using MediatR;

namespace library.Application;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, ApiResponse<List<AuthorDto>>>
{
    private IAuthorService _AuthorService { get; set; }
    public GetAuthorQueryHandler(IAuthorService service)
    {
        _AuthorService = service;
    }
    public async Task<ApiResponse<List<AuthorDto>>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        return await _AuthorService.Get(request.Request);
    }
}
