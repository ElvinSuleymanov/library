namespace library.Domain;

public class BookAuthor:Entity
{
    public int BookId { get; set; }
    public virtual Book Book { get; set; }  
    public int? AuthorId { get; set; }
    public virtual Author Author { get; set; }  
}
