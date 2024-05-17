
namespace library.Domain;

public class Genre:Entity
{
    public ICollection<BookGenre> Books { get; set; }
    public string GenreName { get; set; }
}
