using Shared.Enteties;
using Shared.Interfaces;

namespace Client.Services;

public class UserService : IRepository<User>
{
	public Task<IEnumerable<User>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<User> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<User> CreateAsync(User entity)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(string id, User entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(string id)
	{
		throw new NotImplementedException();
	}
}