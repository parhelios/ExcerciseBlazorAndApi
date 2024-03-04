using DataAccess.Interfaces;
using MongoDB.Driver;
using Shared.Enteties;

namespace DataAccess;

public class UserRepository : IUserRepository
{
     private readonly IMongoCollection<User> _userCollection;
     public UserRepository(MongoDbOptions options)
     {
          var connectionString = $"mongodb://{options.Host}";
          var client = new MongoClient(connectionString);
          var database = client.GetDatabase(options.Database);
          _userCollection = database.GetCollection<User>("Users", new MongoCollectionSettings() { AssignIdOnInsert = true });
     }

     public async Task<IEnumerable<User>> GetAllAsync()
     {
          return await _userCollection.Find(FilterDefinition<User>.Empty).ToListAsync();
     }

     public async Task<User> GetByIdAsync(string id)
     {
          return await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
     }

     public async Task<User> CreateAsync(User entity)
     {
          await _userCollection.InsertOneAsync(entity);
          return entity;
     }

     public async Task UpdateAsync(string id, User entity)
     {
          await _userCollection.ReplaceOneAsync(u => u.Id == id, entity);
     }

     public async Task DeleteAsync(string id)
     {
          await _userCollection.DeleteOneAsync(u => u.Id == id);
     }
}