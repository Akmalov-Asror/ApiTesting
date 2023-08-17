using postgress.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.DTO_s;

public class TaskDto
{
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public DateTime Date { get; set; }
    public Step Status { get; set; }
    public Guid? LessonId { get; set; }
    public Guid? CommentId { get; set; }
}