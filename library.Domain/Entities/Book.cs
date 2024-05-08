namespace library.Domain;

public class Book:Entity
{
    public required Author Author { get; set; }
    public required Genre Genre {get; set;}
}
