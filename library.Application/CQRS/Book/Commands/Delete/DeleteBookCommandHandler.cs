using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ApiResponse<DeleteBookResponse>>
{
    private IBookService _BookService { get; set; }  
    public DeleteBookCommandHandler(IBookService BookService)
    {
        _BookService = BookService;
    }
    public async Task<ApiResponse<DeleteBookResponse>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
       return await _BookService.Delete(request.Request);
    }
}
