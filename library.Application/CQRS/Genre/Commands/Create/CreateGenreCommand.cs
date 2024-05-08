using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class CreateGenreCommand:IRequest<ApiResponse<CreateGenreResponse>>
{
    public CreateGenreRequest  Request {get;set;}
    public CreateGenreCommand(CreateGenreRequest request)
    {
        Request = request;
    }
}
