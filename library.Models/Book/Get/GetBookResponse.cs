using library.Domain;

namespace library.Models;

public class GetBookResponse
{
    public int Id { get; set; } 
    public required string Name {get;set;}
    public List<AuthorDto> Authors {get;set;}
    public List<BookDto> GenreIds {get;set;} 
}

