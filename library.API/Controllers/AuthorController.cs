using library.Application;
using library.Application.Core;
using library.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace library.API;

[ApiController]
[Route("/author")]
public class AuthorController
{
    private IMediator _mediator {get;set;}
    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Route("login")]
    [HttpPost]
    public async Task<ApiResponse<LoginAuthorResponse>> Login ([FromForm] LoginAuthorRequest request) {
        return await _mediator.Send(new LoginAuthorCommand(request));
    }
    [Route("register")]
    [HttpPost]
    public async Task<ApiResponse<RegisterAuthorResponse>> Register ([FromForm] RegisterAuthorRequest request) {
        return await _mediator.Send(new RegisterAuthorCommand(request));
    }
    [HttpGet]
    public async Task<ApiResponse<List<GetAuthorResponse>>> Get([FromQuery]GetAuthorRequest request) {
        return await _mediator.Send(new GetAuthorQuery(request));
    }
}
