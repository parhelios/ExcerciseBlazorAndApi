using Shared.Enteties;

namespace DataAccess.Services;

public class UserService
{
	public List<User> Users { get; set; } = new()
	{
		new User("1", "User1"),
		new User("2", "User2"),
		new User("3", "User3"),
		new User("4", "User4"),
		new User("5", "User5"),
	};
}