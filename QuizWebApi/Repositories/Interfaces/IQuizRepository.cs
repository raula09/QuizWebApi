using QuizWebApi.Models;

namespace QuizWebApi.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<QuizSession?> GetByIdAsync(string id);
        Task CreateAsync(QuizSession session);
        Task UpdateAsync(QuizSession session);
        Task<List<QuizSession>> GetByUserIdAsync(string userId);
    }
}
