namespace library.Models;

public class UpdateBookRequest
{
    public int GenreId {get; set; }
    public int AuthorId {get; set; }    
    public int BookId {get; set; }
    public required string Name {get;set;}

}
