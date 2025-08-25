namespace QuizWebApi.DTOs.Questions
{
    public class CreateQuestionDto
    {
        public string Prompt { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public int CorrectIndex { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
