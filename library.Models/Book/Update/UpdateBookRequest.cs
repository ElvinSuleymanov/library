namespace library.Models;

public class UpdateBookRequest
{
    public int BookId {get; set; }
    public List<int> GenreIds {get; set; }
    public List<int> AuthorIds {get; set; }    
    public required string Name {get;set;}

}
