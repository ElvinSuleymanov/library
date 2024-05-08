using library.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace library.API;

[ApiController]
[Route("/test")]
public class BookController
{
    private IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ApiResponse<GetBookResponse>> Get(GetBookRequest request) {
        return await _mediator.Send(new GetBookQuery(request));
    }
   
}
