using MongoDB.Driver;
using QuizWebApi.Models;
using QuizWebApi.Repositories.Interfaces;

namespace QuizWebApi.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database, IConfiguration config)
        {
            var collectionName = config["MongoDb:UsersCollection"];
            _users = database.GetCollection<User>(collectionName);
        }

        public async Task<User?> GetByEmailAsync(string email) =>
            await _users.Find(u => u.Email == email).FirstOrDefaultAsync();

        public async Task<User?> GetByIdAsync(string id) =>
            await _users.Find(u => u.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User user) =>
            await _users.InsertOneAsync(user);
    }
}
