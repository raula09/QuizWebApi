using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace QuizWebApi.Models
{
    public class QuizSession
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public List<QuizResult> Results { get; set; } = new();
        public int Score { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime EndedAt { get; set; }
    }

    public class QuizResult
    {
        public string QuestionId { get; set; } = string.Empty;
        public string GivenAnswer { get; set; } = string.Empty;
        public bool Correct { get; set; }
    }
}
