namespace library.Domain;

public class Book:Entity
{
    public  Author Author { get; set; }
    public int AuthorId { get; set; }
    public  Genre Genre {get; set;}
    public int GenreId { get; set;} 
    public string BookName { get; set; }
}
