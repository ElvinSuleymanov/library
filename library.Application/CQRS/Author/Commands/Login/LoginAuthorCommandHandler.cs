using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class LoginAuthorCommandHandler : IRequestHandler<LoginAuthorCommand, ApiResponse<LoginAuthorResponse>>
{
    private IAuthorService _authorService {get;set;}
    public LoginAuthorCommandHandler(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    public async Task<ApiResponse<LoginAuthorResponse>> Handle(LoginAuthorCommand request, CancellationToken cancellationToken)
    {
      return await _authorService.Login(request.Request);
    }
}
