using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.Entities;

public class Course
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? ImgUrl { get; set; }
}

