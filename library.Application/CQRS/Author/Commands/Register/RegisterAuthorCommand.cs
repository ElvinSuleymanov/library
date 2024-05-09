using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class RegisterAuthorCommand:IRequest<ApiResponse<RegisterAuthorResponse>>
{
    public RegisterAuthorRequest Request {get;set;}
    public RegisterAuthorCommand(RegisterAuthorRequest request)
    {
        Request = request;
    }
}
