namespace library.Models;

public class GetAuthorRequest
{
    public int? Id { get; set; }
    public int? TopCount { get; set; }  = 10;
}
