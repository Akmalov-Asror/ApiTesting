namespace postgress.Entities;

public class Choices
{
    public Guid Id { get; set; }
    public string? FirstOption { get; set; }
    public string? SecondOption { get; set; }
    public string? ThirdOption { get; set; }
    public string? FourthOption { get; set; }
}