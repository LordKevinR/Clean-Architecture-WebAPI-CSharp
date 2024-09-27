using Application.UseCases.Pets;
using Domain.Entities;
using InterfaceAdapters.DTOs;
using InterfaceAdapters.Models;
using InterfaceAdapters.Presenters;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation_API.Endpoints.Pets
{
    public static class PetsEndpoints
    {
        public static RouteGroupBuilder MapPets(this RouteGroupBuilder builder)
        {
            builder.MapGet("/", GetAll);
            builder.MapPost("/", Create);
            return builder;
        }

        public static async Task<Ok<IEnumerable<PetViewModel>>> GetAll(GetPetUseCase<Pet, PetViewModel> getPetUseCase)
        {
            var pets = await getPetUseCase.ExecuteAsync();
            return TypedResults.Ok(pets);
        }

        public static async Task<Created> Create(PetCreationRequestDTO petCreationRequestDTO, AddPetUseCase<PetCreationRequestDTO> addPetUseCase)
        {
            await addPetUseCase.ExecuteAsync(petCreationRequestDTO);
            return TypedResults.Created();
        }
    }
}
