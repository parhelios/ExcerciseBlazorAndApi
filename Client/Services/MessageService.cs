using Shared.Enteties;
using Shared.Interfaces;

namespace Client.Services;

public class MessageService : IRepository<Message>
{
	public Task<IEnumerable<Message>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Message> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<Message> CreateAsync(Message entity)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(string id, Message entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(string id)
	{
		throw new NotImplementedException();
	}
}