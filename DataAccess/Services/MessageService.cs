using Shared.Enteties;

namespace DataAccess.Services;

public class MessageService
{
	public List<Message> Messages { get; set; } = new()
	{
		new Message("1", "Hello", "User1", DateTime.Now),
		new Message("2", "Hi", "User2", DateTime.Now),
		new Message("3", "Hey", "User1", DateTime.Now),
		new Message("4", "How are you?", "User2", DateTime.Now),
	};
}