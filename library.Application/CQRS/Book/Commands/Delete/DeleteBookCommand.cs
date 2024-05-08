using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class DeleteBookCommand:IRequest<ApiResponse<DeleteBookResponse>>
{
    public DeleteBookRequest Request {get;set;}
    public DeleteBookCommand(DeleteBookRequest request)
    {
        Request = request;
    }
}
