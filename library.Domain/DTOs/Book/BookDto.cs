namespace library.Domain;

public class BookDto
{
    public int Id { get; set;}  
    public string Name { get; set;}
    public List<GenreDto> Genres { get; set;}
    public List<AuthorDto> Authors { get; set;} 
}
