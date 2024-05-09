namespace library.Domain;

public class Author:Entity
{
    public ICollection<Book> Books { get; set; }
    public required string FullName {get; set;}
    public string Email {get; set;}
    public byte[] Password {get; set;}
    public byte[] Salt {get; set;}
}
