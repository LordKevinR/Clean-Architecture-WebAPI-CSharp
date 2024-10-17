using Application.UseCases.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation_API.Endpoints.Users
{
    public static class UsersEndpoints
    {
        public static RouteGroupBuilder MapUsers(this RouteGroupBuilder builder)
        {
            builder.MapGet("/", GetAll);
            return builder;
        }

        public static async Task<Ok<IEnumerable<User>>> GetAll(GetUsersUseCase getUsersUseCase)
        {
            var users = await getUsersUseCase.ExecuteAsync();
            return TypedResults.Ok(users);
        }
    }
}
