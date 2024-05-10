using library.Application;
using library.Application.Core;
using library.Domain;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure;

public class BookService : IBookService
{
    private ApplicationDbContext _context;
    public BookService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ApiResponse<GetBookResponse>> Get(GetBookRequest request)
    {
      var book = await _context.Books
      .Where(x => request.GenreId != null ? request.GenreId == x.GenreId : true)
      .Where(x => request.AuthorId != null ? request.AuthorId == x.AuthorId : true)
      .Where(x => request.BookId != null ? request.BookId == x.Id : true)  
      .Include(x => x.Author)
      .Include(x => x.Genre)
      .Select(s => new ResponseBook{
        FullName = s.Author.FullName,
        GenreId = s.GenreId,
        AuthorId = s.AuthorId,
        Id = s.Id,
        GenreName = s.Genre.GenreName,
        BookName = s.BookName
      })
      .ToListAsync();
      GetBookResponse response = new GetBookResponse { Books = book };
      return ApiResponse<GetBookResponse>.Success(response);
    }
    public async Task<ApiResponse<CreateBookResponse>> Create(CreateBookRequest request) {
      Book book = new Book {AuthorId = request.AuthorId, GenreId = request.GenreId, BookName = request.BookName};
      await _context.Books.AddAsync(book);
      await _context.SaveChangesAsync();
      CreateBookResponse res = new CreateBookResponse { BookId = book.Id};
      return ApiResponse<CreateBookResponse>.Success(res);
    }
    public async Task<ApiResponse<UpdateBookResponse>> Update(UpdateBookRequest request) {
      Book book = new Book {Id=request.BookId, AuthorId = request.AuthorId, GenreId = request.GenreId, BookName = request.Name};
      _context.Books.Update(book);
      await _context.SaveChangesAsync();
      UpdateBookResponse res = new UpdateBookResponse {};
      return ApiResponse<UpdateBookResponse>.Success(res);  
    }
    public async Task<ApiResponse<DeleteBookResponse>> Delete (DeleteBookRequest request) {
      Book book = await _context.Books.FindAsync(request.BookId);
      _context.Books.Remove(book);
      await _context.SaveChangesAsync();
      DeleteBookResponse res = new DeleteBookResponse {};
      return ApiResponse<DeleteBookResponse>.Success(res);
    }
}
