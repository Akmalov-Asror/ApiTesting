using postgress.Entities;

namespace postgress.DTO_s;

public class TestDto
{
    public string? QuestionText { get; set; }
    public int? CorrectAnswerQuestion { get; set; }
    public List<Choices>? Choices { get; set; }
}