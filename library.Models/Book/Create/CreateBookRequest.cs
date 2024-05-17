namespace library.Models;

public class CreateBookRequest
{
    public List<int> GenreIds { get; set; }
    public List<int> AuthorIds { get; set; }
    public required string BookName {get;set;}   
}
