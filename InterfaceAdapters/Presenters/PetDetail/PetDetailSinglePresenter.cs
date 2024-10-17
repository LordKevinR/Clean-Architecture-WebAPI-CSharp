using Application.Interfaces;
using Domain.Entities;

namespace InterfaceAdapters.Presenters.PetDetail
{
    public class PetDetailSinglePresenter : ISinglePresenter<Pet, PetDetailViewModel>
    {
        public PetDetailViewModel Present(Pet entity)
        {
            var pet = new PetDetailViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Owner = entity.Owner,
                FullData = "the pet's name is " + entity.Name + ", it is " + entity.Age + " years old, and the owner is " + entity.Owner,
                Age = entity.Age,
                RecommendedWeight = entity.Age >= 0 ? 2 : entity.Age > 1 ? 15 : entity.Age > 2 ? 50 : 100,
            };
            
            return pet;
        }
    }
}
