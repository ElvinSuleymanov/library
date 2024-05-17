using library.Application.Core;
using library.Domain;
using library.Models;
using MediatR;

namespace library.Application.CQRS.Book.Queries;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, ApiResponse<List<BookDto>>>
{
    private IBookService _BookService {get;set;}
    public GetBookQueryHandler(IBookService BookService)
    {
        _BookService = BookService;
    }
    public async Task<ApiResponse<List<BookDto>>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        return await _BookService.Get(request.Request);
    }
}
