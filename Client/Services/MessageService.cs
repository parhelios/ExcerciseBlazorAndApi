using Shared.DTOs;
using Shared.Interfaces;

namespace Client.Services;

public class MessageService : IRepository<MessageDto>
{
	private readonly HttpClient _httpClient;

	public MessageService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("API");
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