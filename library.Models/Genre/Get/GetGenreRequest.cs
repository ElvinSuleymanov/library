namespace library.Models;

public class GetGenreRequest
{
    public int? TopGenre {get;set;} = 5;
    public int? GenreId { get; set; }   
}
