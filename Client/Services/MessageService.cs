using Shared.DTOs;
using Shared.Enteties;
using Shared.Interfaces;

namespace Client.Services;

public class MessageService : IRepository<MessageDto>
{
	private readonly HttpClient _httpClient;

	//public List<MessageDto> Messages { get; set; } = new()
	//{
	//	new MessageDto("1", "Hello", "User1", DateTime.Now),
	//	new MessageDto("2", "Hi", "User2", DateTime.Now),
	//	new MessageDto("3", "Hey", "User1", DateTime.Now),
	//	new MessageDto("4", "How are you?", "User2", DateTime.Now),
	//};

	public MessageService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("api");
	}


	public async Task<IEnumerable<MessageDto>> GetAllAsync()
	{
		var response = await _httpClient.GetAsync("/messages");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<MessageDto>();

		}
		var result = await response.Content.ReadFromJsonAsync<IEnumerable<MessageDto>>();
		return result ?? Enumerable.Empty<MessageDto>();

		//return Messages;
	}

	public Task<MessageDto> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public async Task<MessageDto> CreateAsync(MessageDto entity)
	{
		var response = await _httpClient.PostAsJsonAsync("/people", entity);

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		return entity;

		//var newMessage = new MessageDto(entity.Id, entity.Text, entity.Author, entity.CreatedAt);
		//Messages.Add(newMessage);
		//return newMessage;
	}

	public Task UpdateAsync(string id, MessageDto entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(string id)
	{
		throw new NotImplementedException();
	}
}