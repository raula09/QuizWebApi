.using QuizWebApi.Models;

namespace QuizWebApi.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetByIdAsync(string id);
        Task<List<Question>> GetAllAsync();
        Task<List<Question>> GetRandomQuestionsAsync(string category, int count);
        Task CreateAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(string id);
        Task CreateAsync(Question question);
    }
}
