
using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.DTOs;

namespace InterfaceAdapters.Mappers
{
    public class PetMapper : IMapper<PetCreationRequestDTO, Pet>
    {
        public Pet ToEntity(PetCreationRequestDTO dto)
        {
            var pet = new Pet()
            {
                Name = dto.Name,
                Age = dto.Age,
                Owner = dto.Owner,
            };

            return pet;
        }
    }
}
