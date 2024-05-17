namespace library.Models;

public class GetBookRequest
{
    public int? BookId { get; set;}
    public List<int>? GenreIds { get; set;}
    public List<int>? AuthorIds {get;set;}
}
