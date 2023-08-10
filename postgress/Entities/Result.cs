using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.Entities;

public class Result
{
    public Guid Id { get; set; }
    public string? ImgPath { get; set; }
    public Guid? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    public Guid? DescriptionCourseId { get; set; }
    [ForeignKey(nameof(DescriptionCourseId))]
    public DescriptionCourse? DescriptionCourse { get; set; }

}