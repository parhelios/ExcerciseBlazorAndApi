using Shared.DTOs;
using Shared.Interfaces;

namespace Client.Services;

public class UserService : IRepository<UserDto>
{

	private readonly HttpClient _httpClient;

	public UserService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("API");
	}

	public async Task<IEnumerable<UserDto>> GetAllAsync()
	{
		var response = await _httpClient.GetAsync("/messages");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<UserDto>();

		}
		var result = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
		return result ?? Enumerable.Empty<UserDto>();
	}

	public Task<UserDto> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public async Task<UserDto> CreateAsync(UserDto entity)
	{
		var response = await _httpClient.PostAsJsonAsync("/people", entity);

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		return entity;
	}

	public Task UpdateAsync(string id, UserDto entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(string id)
	{
		throw new NotImplementedException();
	}
}