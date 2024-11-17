using MongoDB.Driver;
using MongoDB.Bson;
using ToDoApp.Models;

namespace ToDoApp.Repositories
{
    public class ToDoRepository
    {
        private readonly IMongoCollection<ToDoItem> _toDoCollection;

        public ToDoRepository(IMongoDatabase database)
        {
            _toDoCollection = database.GetCollection<ToDoItem>("ToDoItems");
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _toDoCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddAsync(ToDoItem item)
        {
            await _toDoCollection.InsertOneAsync(item);
        }

        public async Task ToggleCompleteAsync(string id)
        {
            var filter = Builders<ToDoItem>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<ToDoItem>.Update.Set("IsComplete", true);
            await _toDoCollection.UpdateOneAsync(filter, update);
        }
    }
}
