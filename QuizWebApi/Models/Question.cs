using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace QuizWebApi.Models
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Prompt { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public int CorrectIndex { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Difficulty { get; set; } = "easy";
    }
}
