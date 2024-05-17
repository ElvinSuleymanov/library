namespace library.Domain;


 public class Book:Entity
{
    public string Name { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }  
}