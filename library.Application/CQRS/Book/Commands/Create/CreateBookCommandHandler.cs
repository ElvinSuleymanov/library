using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ApiResponse<CreateBookResponse>>
{
    private IBookService _BookService { get; set; }  
    public CreateBookCommandHandler(IBookService BookService)
    {
        _BookService = BookService;
    }
    public async Task<ApiResponse<CreateBookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        return await _BookService.Create(request.Request);
    }
}
