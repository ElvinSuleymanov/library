using library.Application.Core;
using library.Domain;
using library.Models;

namespace library.Application;

public interface IBookService
{
    public Task<ApiResponse<List<BookDto>>> Get(GetBookRequest request); 
    public Task<ApiResponse<CreateBookResponse>> Create(CreateBookRequest request); 
    public Task<ApiResponse<DeleteBookResponse>> Delete (DeleteBookRequest request);
    public Task<ApiResponse<UpdateBookResponse>> Update(UpdateBookRequest request);

}
