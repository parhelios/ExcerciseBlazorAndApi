using DataAccess.Interfaces;
using Shared.DTOs;
using Shared.Enteties;

namespace API.Extensions;

public static class MessageEndpointExtensions
{
     public static void MapMessageEndpoints(this IEndpointRouteBuilder endpointBuilder)
     {
          var group = endpointBuilder.MapGroup("api/messages");

          group.MapGet("", async (IMessageRepository repository) =>
          {
               var messages = await repository.GetAllAsync();
               return messages.Select(m => m.ToDto<MessageDto>());
          });

          group.MapGet("{id}", async (IMessageRepository repository, string id) =>
          {
               var message = await repository.GetByIdAsync(id);
               return message.ToDto<MessageDto>();
          });

          group.MapPost("", async (IMessageRepository repository, MessageDto messageDto) =>
          {
               var message = messageDto.ToEntity<Message>();
               await repository.CreateAsync(message);
               return message.ToDto<MessageDto>();
          });

          group.MapPut("{id}", async (IMessageRepository repository, string id, MessageDto messageDto) =>
          {
               var message = messageDto.ToEntity<Message>();
               await repository.UpdateAsync(id, message);
          });

          group.MapDelete("{id}", async (IMessageRepository repository, string id) =>
          {
               await repository.DeleteAsync(id);
          });
     }
}