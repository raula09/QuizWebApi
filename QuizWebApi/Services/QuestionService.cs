using QuizWebApi.DTOs.Questions;
using QuizWebApi.Models;
using QuizWebApi.Repositories.Interfaces;
using QuizWebApi.Services.Interfaces;

namespace QuizWebApi.Services
{

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repo;

        public QuestionService(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Question>> GetRandomQuestionsAsync(string category, int count) =>
            await _repo.GetRandomQuestionsAsync(category, count);

        public async Task<Question?> GetByIdAsync(string id) =>
            await _repo.GetByIdAsync(id);

        public async Task CreateQuestionAsync(CreateQuestionDto dto)
        {
            var question = new Question
            {
                Prompt = dto.Prompt,
                Options = dto.Options,
                CorrectIndex = dto.CorrectIndex,
                Category = dto.Category
            };
            await _repo.CreateAsync(question);
        }
    }
}
