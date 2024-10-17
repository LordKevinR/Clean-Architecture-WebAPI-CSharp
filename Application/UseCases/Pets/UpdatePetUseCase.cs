using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Pets
{
    public class UpdatePetUseCase<TDTO>
    {
        private readonly IRepository<Pet> repository;
        private readonly IMapper<TDTO, Pet> mapper;

        public UpdatePetUseCase(IRepository<Pet> repository, IMapper<TDTO, Pet> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(int id, TDTO petDTO)
        {
            var pet = mapper.ToEntity(petDTO);

            if (string.IsNullOrEmpty(pet.Name))
                throw new BadRequestValidationException("The pet's name is required");

            await repository.UpdateAsync(id, pet);
        }
    }
}
