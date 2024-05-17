using library.Application.Core;
using library.Domain;
using library.Models;
using MediatR;

namespace library.Application;

public class GetAuthorQuery:IRequest<ApiResponse<List<AuthorDto>>>
{
    public GetAuthorRequest Request { get; set; }
    public GetAuthorQuery(GetAuthorRequest request)
    {
        Request = request;
    }
}
