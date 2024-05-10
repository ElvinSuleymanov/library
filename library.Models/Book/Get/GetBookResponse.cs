using library.Domain;

namespace library.Models;

public class GetBookResponse
{
    public required List<ResponseBook> Books { get; set;}    
}

public class ResponseBook:Book {
    public string FullName { get; set; }
    public string GenreName { get; set; }
}