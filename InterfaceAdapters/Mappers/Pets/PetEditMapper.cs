using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.DTOs.Pets;

namespace InterfaceAdapters.Mappers.Pets
{
    public class PetEditMapper : IMapper<PetUpdateRequestDTO, Pet>
    {
        public Pet ToEntity(PetUpdateRequestDTO entity)
        {
            var pet = new Pet()
            {
                Name = entity.Name,
                Age = entity.Age,
                Owner = entity.Owner,
            };

            return pet;
        }
    }
}
