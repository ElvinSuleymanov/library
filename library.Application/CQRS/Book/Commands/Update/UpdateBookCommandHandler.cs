using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class UpdateBookCommandHandler:IRequestHandler<UpdateBookCommand, ApiResponse<UpdateBookResponse>>
{
    private IBookService _BookService { get; set; }  
    public UpdateBookCommandHandler(IBookService BookService)
    {
        _BookService = BookService;
    }

    public async Task<ApiResponse<UpdateBookResponse>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
       return await _BookService.Update(request.Request);
    }
}
