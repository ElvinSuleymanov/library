namespace library.Domain;

public class AuthorDto
{  
    public int Id { get; set; }
    public required string AuthorName {get;set;}
    public  required string Email {get;set;}  
    public List<BookDto> Books {get; set;}
}
