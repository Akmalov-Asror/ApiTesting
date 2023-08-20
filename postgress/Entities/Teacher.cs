namespace postgress.Entities;

public class Teacher : IEntity
{
    public Guid Id { get; set; }
    public string? Img { get; set; }
    public string? FullName { get; set; }
    public string? Desc { get; set; }

}