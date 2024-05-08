namespace library.Models;

public class CreateBookRequest
{
    public int GenreId { get; set; }
    public int AuthorId { get; set; }
    public required string BookName {get;set;}   
}
