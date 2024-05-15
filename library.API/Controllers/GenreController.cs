using library.Application;
using library.Application.Core;
using library.Domain;
using library.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace library.API;

[ApiController]
[Route("/genre")]
public class GenreController
{
    private IMediator _mediator;
    public GenreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ApiResponse<List<GenreDto>>> Get([FromQuery] GetGenreRequest request) {
        return await _mediator.Send(new GetGenreQuery(request));
    }
    [HttpPost]
    public async Task<ApiResponse<CreateGenreResponse>> Create([FromForm] CreateGenreRequest request) {
        return await _mediator.Send(new CreateGenreCommand(request));
    }
}
