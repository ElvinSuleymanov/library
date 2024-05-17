namespace library.Domain;

public class BookGenre:Entity
{
    public Book Book { get; set; }  
    public int BookId { get; set; } 
    public Genre Genre { get; set; }
    public int GenreId {get;set;}
}
