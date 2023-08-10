using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.Entities;

public class Review
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public string? Name { get; set; }
    public Guid? DescriptionCourseId { get; set; }
    [ForeignKey(nameof(DescriptionCourseId))]
    public DescriptionCourse? DescriptionCourse { get; set; }
}