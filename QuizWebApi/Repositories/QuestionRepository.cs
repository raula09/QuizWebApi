using MongoDB.Driver;
using QuizWebApi.Models;
using QuizWebApi.Repositories.Interfaces;

namespace QuizWebApi.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoCollection<Question> _questions;

        public QuestionRepository(IMongoDatabase db, IConfiguration config)
        {
            var collectionName = config["MongoDb:QuestionsCollection"];
            _questions = db.GetCollection<Question>(collectionName);
        }

        public async Task<Question?> GetByIdAsync(string id) =>
            await _questions.Find(q => q.Id == id).FirstOrDefaultAsync();

        public async Task<List<Question>> GetAllAsync() =>
            await _questions.Find(_ => true).ToListAsync();

        public async Task<List<Question>> GetRandomQuestionsAsync(string category, int count)
        {
            var filter = Builders<Question>.Filter.Eq(q => q.Category, category);
            return await _questions.Aggregate()
                .Match(filter)
                .Sample(count)
                .ToListAsync();
        }

        public async Task CreateAsync(Question question) =>
            await _questions.InsertOneAsync(question);

        public async Task UpdateAsync(Question question) =>
            await _questions.ReplaceOneAsync(q => q.Id == question.Id, question);

        public async Task DeleteAsync(string id) =>
            await _questions.DeleteOneAsync(q => q.Id == id);
    }
}
