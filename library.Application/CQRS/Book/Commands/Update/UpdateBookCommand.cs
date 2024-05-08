using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class UpdateBookCommand:IRequest<ApiResponse<UpdateBookResponse>>
{
    public UpdateBookRequest Request { get; set; }
    public UpdateBookCommand(UpdateBookRequest request)
    {
        Request  = request;
    }
}
