using Application.UseCases.Pets;
using Domain.Entities;
using FluentValidation;
using InterfaceAdapters.DTOs;
using InterfaceAdapters.Models;
using InterfaceAdapters.Presenters.PetDetail;
using InterfaceAdapters.Presenters.Pets;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation_API.Endpoints.Pets
{
    public static class PetsEndpoints
    {
        public static RouteGroupBuilder MapPets(this RouteGroupBuilder builder)
        {
            builder.MapGet("/", GetAll);
            builder.MapGet("/details", GetWWithDetail);
            builder.MapPost("/", Create);
            return builder;
        }

        public static async Task<Ok<IEnumerable<PetViewModel>>> GetAll(GetPetUseCase<Pet, PetViewModel> getPetUseCase)
        {
            var pets = await getPetUseCase.ExecuteAsync();
            return TypedResults.Ok(pets);
        }

        public static async Task<Ok<IEnumerable<PetDetailViewModel>>> GetWWithDetail(GetPetUseCase<Pet, PetDetailViewModel> getPetUseCase)
        {
            var pets = await getPetUseCase.ExecuteAsync();
            return TypedResults.Ok(pets);
        }

        public static async Task<Results<Created, ValidationProblem>> Create(PetCreationRequestDTO petCreationRequestDTO, AddPetUseCase<PetCreationRequestDTO> addPetUseCase, IValidator<PetCreationRequestDTO> validator)
        {
            var result = await validator.ValidateAsync(petCreationRequestDTO);

            if (!result.IsValid)
            {
                return TypedResults.ValidationProblem(result.ToDictionary());
            }

            await addPetUseCase.ExecuteAsync(petCreationRequestDTO);
            return TypedResults.Created();
        }
    }
}
