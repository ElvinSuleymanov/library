using library.Domain;

namespace library.Models;

public class GetAuthorResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }    
    public string Email { get; set; }
    public int? BookCount {get;set;}
    public List<Book> Books { get; set; }
}
