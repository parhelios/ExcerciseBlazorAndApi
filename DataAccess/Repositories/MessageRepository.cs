using DataAccess.Interfaces;
using MongoDB.Driver;
using Shared.Enteties;

namespace DataAccess.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly IMongoCollection<Message> _collection;

    public MessageRepository(MongoDbOptions options)
    {
        var connectionString = $"mongodb://{options.Host}";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(options.Database);
        _collection = database.GetCollection<Message>("Messages", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public async Task<IEnumerable<Message>> GetAllAsync()
    {
        return await _collection.Find(FilterDefinition<Message>.Empty).ToListAsync();
    }

    public async Task<Message> GetByIdAsync(string id)
    {
        return await _collection.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Message> CreateAsync(Message entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(string id, Message entity)
    {
        await _collection.ReplaceOneAsync(m => m.Id == id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(m => m.Id == id);
    }
}