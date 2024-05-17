using System.Security.Cryptography.Xml;
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
  public async Task<ApiResponse<List<BookDto>>> Get(GetBookRequest request)
  {
    bool isBookIdNull = request.BookId is null;
    bool isGenreIdsNull = request.GenreIds is null;
    bool isAuthorIdsNull = request.AuthorIds is null;
    var books = await _context.Books
    .Where(x => isBookIdNull || request.BookId == x.Id)
    .Where(b => isGenreIdsNull || b.BookGenres.All(bg => request.GenreIds.Contains(bg.GenreId)))
    .Where(b => isAuthorIdsNull || b.BookAuthors.All(ba => request.AuthorIds.Contains((int)ba.AuthorId)))
    .Include(x => x.BookAuthors)
        .ThenInclude(x => x.Author)
    .Include(x => x.BookGenres)
        .ThenInclude(x => x.Genre)
    .Select(x => new BookDto
    {
      Id = x.Id,
      Name = x.Name,
      Genres = x.BookGenres.Select(a => new GenreDto { GenreName = a.Genre.GenreName, Id = a.Genre.Id, BookCount = x.BookGenres.Count }).ToList(),
    })
    .ToListAsync();
    return ApiResponse<List<BookDto>>.Success(books);
  }
  public async Task<ApiResponse<CreateBookResponse>> Create(CreateBookRequest request)
  {


    Book book = new() { Name = request.BookName };
    await _context.Books.AddAsync(book);
    await _context.SaveChangesAsync();
    foreach (var authorId in request.AuthorIds)
    {
      await _context.BookAuthors.AddAsync(new BookAuthor { BookId = book.Id, AuthorId = authorId });
    }
    foreach (var genreId in request.GenreIds)
    {
      await _context.BookGenres.AddAsync(new BookGenre { BookId = book.Id, GenreId = genreId });
    }

    await _context.SaveChangesAsync();


    CreateBookResponse res = new CreateBookResponse { BookId = book.Id };
    return ApiResponse<CreateBookResponse>.Success(res);
  }
  public async Task<ApiResponse<UpdateBookResponse>> Update(UpdateBookRequest request)
  {
    Book target = await _context.Books.FindAsync(request.BookId);
    target.Name = request.Name;
   List<BookAuthor> ba = await _context.BookAuthors.Where(x => x.BookId == request.BookId).ToListAsync();
   List<BookGenre> bg = await _context.BookGenres.Where(x => x.BookId == request.BookId).ToListAsync();

    
    foreach (int Id in request.GenreIds)
    {
     _context.BookAuthors.Add(new BookAuthor { BookId = request.BookId, AuthorId = Id });
    }
    foreach (int Id in request.AuthorIds) {
      _context.BookGenres.Add(new BookGenre {GenreId = Id, BookId = request.BookId});
    }
    foreach (BookAuthor item in ba) {
      _context.BookAuthors.Remove(item);
    }
    foreach (BookGenre item in bg) {
      _context.BookGenres.Remove(item);
    }
    //
    target.BookAuthors = request.AuthorIds.Select(x => new BookAuthor
    {
      BookId = request.BookId,
      AuthorId = x
    }).ToList();
    target.BookGenres = request.GenreIds.Select(x => new BookGenre
    {
      BookId = request.BookId,
      GenreId = x
    }).ToList();
    _context.Books.Update(target);
    await _context.SaveChangesAsync();
    UpdateBookResponse res = new UpdateBookResponse { };
    return ApiResponse<UpdateBookResponse>.Success(res);
  }
  public async Task<ApiResponse<DeleteBookResponse>> Delete(DeleteBookRequest request)
  {
    Book book = await _context.Books.FindAsync(request.BookId);
    _context.Books.Remove(book);
    await _context.SaveChangesAsync();
    DeleteBookResponse res = new DeleteBookResponse { };
    return ApiResponse<DeleteBookResponse>.Success(res);
  }
}
