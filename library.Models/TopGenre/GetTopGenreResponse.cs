using library.Domain;

namespace library.Models;

public class GetTopGenreResponse
{
    public Genre Genre { get; set; }
    public int? BookCount { get; set; }
}

