
namespace library.Domain;

public class Genre:Entity
{
    public ICollection<Book> Books { get; set; }
    public string GenreName { get; set; }

}
