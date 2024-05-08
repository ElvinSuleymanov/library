using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class CreateBookCommand:IRequest<ApiResponse<CreateBookResponse>>
{
    public CreateBookRequest Request { get; set; }
    public CreateBookCommand(CreateBookRequest request)
    {
        Request = request;
    }
}
