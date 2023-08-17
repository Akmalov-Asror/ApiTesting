using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.Entities;

public class Comment
{   
    public Guid Id { get; set; }
    public Guid? TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public Task? Task { get; set; }
    public Guid? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }  
    public string? Desc { get; set; }
    public string? DocumentPath { get; set; }
}