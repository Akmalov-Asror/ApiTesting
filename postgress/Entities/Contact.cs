namespace postgress.Entities;

public class Contact
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Number { get; set; }
    public string? ReturnCall { get; set; }
}