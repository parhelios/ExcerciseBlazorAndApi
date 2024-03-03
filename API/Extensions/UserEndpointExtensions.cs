using DataAccess.Interfaces;
using Shared.DTOs;
using Shared.Enteties;

namespace API.Extensions;

public static class UserEndpointExtensions
{
     public static void MapUserEndpoints(this IEndpointRouteBuilder endpointBuilder)
     {
          var group = endpointBuilder.MapGroup("api/users");

          group.MapGet("", async (IUserRepository repository) =>
          {
               var users = await repository.GetAllAsync();
               return users.Select(u => u.ToDto<UserDto>());
          });

          group.MapGet("{id}", async (IUserRepository repository, string id) =>
          {
               var user = await repository.GetByIdAsync(id);
               return user.ToDto<UserDto>();
          });

          group.MapPost("", async (IUserRepository repository, UserDto userDto) =>
          {
               var user = userDto.ToEntity<User>();
               await repository.CreateAsync(user);
               return user.ToDto<UserDto>();
          });

          group.MapPut("{id}", async (IUserRepository repository, string id, UserDto userDto) =>
          {
               var user = userDto.ToEntity<User>();
               await repository.UpdateAsync(id, user);
          });

          group.MapDelete("{id}", async (IUserRepository repository, string id) =>
          {
               await repository.DeleteAsync(id);
          });
     }
}