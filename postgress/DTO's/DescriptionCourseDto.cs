using postgress.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.DTO_s;

public class DescriptionCourseDto
{
    public string? Title { get; set; }
    public string? Review { get; set; }
    public Guid? CourseId { get; set; }
}