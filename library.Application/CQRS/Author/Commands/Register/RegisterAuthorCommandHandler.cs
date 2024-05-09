using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class RegisterAuthorCommandHandler : IRequestHandler<RegisterAuthorCommand, ApiResponse<RegisterAuthorResponse>>
{
    private IAuthorService _authorService { get; set; }    
    public RegisterAuthorCommandHandler(IAuthorService authorService)
    {
       _authorService =  authorService;
    }
    public async Task<ApiResponse<RegisterAuthorResponse>> Handle(RegisterAuthorCommand request, CancellationToken cancellationToken)
    {
        return await _authorService.Register(request.Request);
    }
}
