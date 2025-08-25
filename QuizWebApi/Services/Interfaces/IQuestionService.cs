using QuizWebApi.DTOs.Questions;
using QuizWebApi.Models;

namespace QuizWebApi.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<Question>> GetRandomQuestionsAsync(string category, int count);
        Task<Question?> GetByIdAsync(string id);
        Task CreateQuestionAsync(CreateQuestionDto dto);
    }
}
