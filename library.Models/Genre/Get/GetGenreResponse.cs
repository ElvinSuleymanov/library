using library.Domain;

namespace library.Models;

public class GetGenreResponse
{
     public int Id { get; set; }
     public string Name { get; set; }
     public int? BookCount {get; set; }
     public List<GetBookResponse> Books { get; set; }
}
