using library.Domain;

namespace library.Models;

public class GetBookResponse
{
    public required List<Book> Books { get; set;}    
}
