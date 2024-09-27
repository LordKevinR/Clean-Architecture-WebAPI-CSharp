using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Pets
{
    public class AddPetUseCase<TDTO>
    {
        private readonly IRepository<Pet> repository;
        private readonly IMapper<TDTO, Pet> mapper;

        public AddPetUseCase(IRepository<Pet> repository, IMapper<TDTO, Pet> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO petDTO)
        {
            var pet = mapper.ToEntity(petDTO);

            if (string.IsNullOrEmpty(pet.Name))
                throw new BadRequestValidationException("The pet's name is required");

            await repository.AddAsync(pet);
        }
    }
}
