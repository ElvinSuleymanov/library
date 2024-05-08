using library.Application;
using library.Application.Core;
using library.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace library.API;

[ApiController]
[Route("/top-genre")]
public class TopGenreController
{
    private IMediator _mediator { get; set; }
    public TopGenreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ApiResponse<GetTopGenreResponse>> Get([FromQuery] GetTopGenreRequest request) {
      return await _mediator.Send(new GetTopGenreQuery(request));
    }
}
