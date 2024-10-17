using Application.Interfaces;
using Domain.Entities;

namespace InterfaceAdapters.Presenters.Pets
{
    public class PetSinglePresenter : ISinglePresenter<Pet, PetViewModel>
    {
        public PetViewModel Present(Pet entity)
        {
            var pet = new PetViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Owner = entity.Owner,
                FullData = "the pet's name is " + entity.Name + ", it is " + entity.Age + " years old, and the owner is " + entity.Owner
            };

            return pet;
        }
    }
}
