using library.Application;
using library.Application.Core;
using library.Application.CQRS.Book.Queries;
using library.Domain;
using library.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace library.API;

[Authorize]
[ApiController]
[Route("/book")]
public class BookController
{
    private IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ApiResponse<List<BookDto>>> Get([FromQuery] GetBookRequest request)
    {
        return await _mediator.Send(new GetBookQuery(request));
    }
    [HttpPost]
    public async Task<ApiResponse<CreateBookResponse>> Create([FromForm] CreateBookRequest request)
    {
        return await _mediator.Send(new CreateBookCommand(request));
    }
    [HttpPut]
    public async Task<ApiResponse<UpdateBookResponse>> Update([FromForm] UpdateBookRequest request)
    {
        return await _mediator.Send(new UpdateBookCommand(request));
    }
    [HttpDelete]
    public async Task<ApiResponse<DeleteBookResponse>> Delete([FromQuery] DeleteBookRequest request)
    {
        return await _mediator.Send(new DeleteBookCommand(request));
    }
}
