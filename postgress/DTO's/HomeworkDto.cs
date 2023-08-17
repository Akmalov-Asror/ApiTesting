using postgress.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace postgress.DTO_s;

public class HomeworkDto
{
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }

}