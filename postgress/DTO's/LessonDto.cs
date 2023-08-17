using postgress.Entities;

namespace postgress.DTO_s;

public class LessonDto
{
    public Guid? CourseId { get; set; }
    public string? Title { get; set; }
    public List<string>? VideoUrl { get; set; }
    public List<string>? Info { get; set; }
}