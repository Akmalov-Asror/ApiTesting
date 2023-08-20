using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.Entities;

public class Task : IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public DateTime Date { get; set; }
    public Step Status { get; set; }
    public Guid? LessonId { get; set;}
    [ForeignKey(nameof(LessonId))]
    public Lesson? Lesson { get; set; }
    public Guid? CommentId { get; set; }
    [ForeignKey(nameof(CommentId))]
    public Comment? Comment { get; set; }

}