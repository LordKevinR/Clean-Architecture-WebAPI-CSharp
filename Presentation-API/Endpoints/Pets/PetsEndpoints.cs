using Application.UseCases.Pets;
using Domain.Entities;
using FluentValidation;
using InterfaceAdapters.DTOs.Pets;
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
            builder.MapGet("/{id:int}", GetById);
            builder.MapGet("/details", GetWithDetail);
            builder.MapGet("/details/{id:int}", GetDetailsById);
            builder.MapPost("/", Create);
            builder.MapPut("/{id:int}", Update);
            builder.MapDelete("/{id:int}", Delete);
            return builder;
        }

        public static async Task<Ok<IEnumerable<PetViewModel>>> GetAll(GetPetUseCase<Pet, PetViewModel> getPetUseCase)
        {
            var pets = await getPetUseCase.ExecuteAsync();
            return TypedResults.Ok(pets);
        }
                
        public static async Task<Ok<PetViewModel>> GetById(int id, GetSinglePetUseCase<Pet, PetViewModel> getSinglePetUseCase)
        {
            var pet = await getSinglePetUseCase.ExecuteAsync(id);
            return TypedResults.Ok(pet);
        }                
        
        public static async Task<Ok<PetDetailViewModel>> GetDetailsById(int id, GetSinglePetUseCase<Pet, PetDetailViewModel> getSinglePetUseCase)
        {
            var pet = await getSinglePetUseCase.ExecuteAsync(id);
            return TypedResults.Ok(pet);
        }

        public static async Task<Ok<IEnumerable<PetDetailViewModel>>> GetWithDetail(GetPetUseCase<Pet, PetDetailViewModel> getPetUseCase)
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

        public static async Task<Results<Ok, ValidationProblem>> Update(int id, PetUpdateRequestDTO petEditRequestDTO, UpdatePetUseCase<PetUpdateRequestDTO> updatePetUseCase, IValidator<PetUpdateRequestDTO> validator)
        {
            var result = await validator.ValidateAsync(petEditRequestDTO);

            if (!result.IsValid)
            {
                return TypedResults.ValidationProblem(result.ToDictionary());
            }

            await updatePetUseCase.ExecuteAsync(id, petEditRequestDTO);
            return TypedResults.Ok();
        }

        public static async Task<Ok> Delete(int id, DeletePetUseCase deletePetUseCase)
        {
            await deletePetUseCase.ExecuteAsync(id);
            return TypedResults.Ok();
        }
    }
}
