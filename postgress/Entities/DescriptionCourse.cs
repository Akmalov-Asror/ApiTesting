using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.Entities;

public class DescriptionCourse : IEntity
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Review { get; set; }
    public Guid? CourseId { get; set; }
    [ForeignKey(nameof(CourseId))]
    public Course? Course { get; set; }
}