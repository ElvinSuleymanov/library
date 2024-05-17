namespace library.Domain;

public class Author:Entity
{
    public required string FullName {get; set;}
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public string Email {get; set;}
    //These are nullable because i had to add seed data :(
    public byte[]? Password {get; set;}
    public byte[]? Salt {get; set;}
}
