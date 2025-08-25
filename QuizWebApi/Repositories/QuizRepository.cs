using MongoDB.Driver;
using QuizWebApi.Models;
using QuizWebApi.Repositories.Interfaces;

namespace QuizWebApi.Repositories
{

    public class QuizRepository : IQuizRepository
    {
        private readonly IMongoCollection<QuizSession> _sessions;

        public QuizRepository(IMongoDatabase db, IConfiguration config)
        {
            var collectionName = config["MongoDb:QuizSessionsCollection"];
            _sessions = db.GetCollection<QuizSession>(collectionName);
        }

        public async Task<QuizSession?> GetByIdAsync(string id) =>
            await _sessions.Find(s => s.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(QuizSession session) =>
            await _sessions.InsertOneAsync(session);

        public async Task UpdateAsync(QuizSession session) =>
            await _sessions.ReplaceOneAsync(s => s.Id == session.Id, session);

        public async Task<List<QuizSession>> GetByUserIdAsync(string userId) =>
            await _sessions.Find(s => s.UserId == userId).ToListAsync();
    }
}
