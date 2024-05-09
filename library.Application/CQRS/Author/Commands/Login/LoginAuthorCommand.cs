using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class LoginAuthorCommand:IRequest<ApiResponse<LoginAuthorResponse>>
{
    public LoginAuthorRequest Request { get; set; }
    public LoginAuthorCommand(LoginAuthorRequest request)
    {
        Request = request;
    }
}
