using postgress.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.DTO_s;

public class ResultDto
{
    public string? ImgPath { get; set; }
    public Guid? DescriptionCourseId { get; set; }
}