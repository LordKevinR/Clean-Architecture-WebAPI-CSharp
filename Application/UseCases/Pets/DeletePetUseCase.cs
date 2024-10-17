
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Pets
{
    public class DeletePetUseCase
    {
        private readonly IRepository<Pet> repository;

        public DeletePetUseCase(IRepository<Pet> repository)
        {
            this.repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestValidationException("Id must be greater than 0");

            await repository.DeleteAsync(id);
        }
    }
}
