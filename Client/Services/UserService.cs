using Shared.DTOs;
using Shared.Enteties;
using Shared.Interfaces;

namespace Client.Services;

public class UserService : IRepository<UserDto>
{

	private readonly HttpClient _httpClient;

	public List<UserDto> Users { get; set; } = new()
	{
		new UserDto("1", "User1"),
		new UserDto("2", "User2"),
		new UserDto("3", "User3"),
		new UserDto("4", "User4"),
		new UserDto("5", "User5"),
	};

	public UserService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("api");
	}

	public async Task<IEnumerable<UserDto>> GetAllAsync()
	{
		//var response = await _httpClient.GetAsync("/users");

		//if (!response.IsSuccessStatusCode)
		//{
		//	return Enumerable.Empty<UserDto>();

		//}
		//var result = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
		//return result ?? Enumerable.Empty<UserDto>();

		return Users;
	}

	public Task<UserDto> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public async Task<UserDto> CreateAsync(UserDto entity)
	{
		//var response = await _httpClient.PostAsJsonAsync("/people", entity);

		//if (!response.IsSuccessStatusCode)
		//{
		//	return null;
		//}

		//return entity;
		var newUser = new UserDto(entity.Id, entity.Username);
		Users.Add(newUser);
		return newUser;
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