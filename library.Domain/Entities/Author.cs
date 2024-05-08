namespace library.Domain;

public class Author:Entity
{
    public required string FullName {get; set;}
    public ICollection<Book> Books { get; set; }
}
