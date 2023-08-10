using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.Entities;

public class Homework
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    public Guid? UserId { get; set;}
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    public Guid? TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public Task? Task{ get; set; }

}