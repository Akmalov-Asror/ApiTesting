namespace postgress.Entities;

public class Test
{
    public Guid Id { get; set; }
    public string? QuestionText { get; set; }
    public int? CorrectAnswerQuestion { get; set; }
    public List<Choices>? Choices { get; set; }

}