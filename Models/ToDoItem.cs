using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoApp.Models
{
    public class ToDoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Task { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
    }
}
