namespace library.Domain;

public class GenreDto
{
    public int Id { get; set; } 
    public required string GenreName { get; set; }
    public int? BookCount {get;set;}
    public List<BookDto> Books { get; set; }
}
