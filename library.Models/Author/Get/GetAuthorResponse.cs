using library.Domain;

namespace library.Models;

public class GetAuthorResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }    
    public string Email { get; set; }
    public int? BookCount {get;set;}
    public List<BookDto> Books { get; set; }
}
