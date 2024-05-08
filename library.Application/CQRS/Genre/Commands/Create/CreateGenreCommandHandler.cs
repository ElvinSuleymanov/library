using library.Application.Core;
using library.Models;
using MediatR;

namespace library.Application;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, ApiResponse<CreateGenreResponse>>
{
    public IGenreService GenreService { get; set; }
    public CreateGenreCommandHandler(IGenreService service)
    {
        GenreService = service;
    }
    public async Task<ApiResponse<CreateGenreResponse>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
       return await GenreService.Create(request.Request);
    }
}
