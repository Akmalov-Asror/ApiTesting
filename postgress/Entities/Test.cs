namespace postgress.Entities;

public class Test
{
    public Guid Id { get; set; }
    public string? QuestionText { get; set; }
    public int? CorrectAnswerQuestion { get; set; }
    public List<string>? Choices { get; set; }

}