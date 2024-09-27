using Application.Interfaces;
using Domain.Entities;

namespace InterfaceAdapters.Presenters.PetDetail
{
    public class PetDetailPresenter : IPresenter<Pet, PetDetailViewModel>
    {
        public IEnumerable<PetDetailViewModel> Present(IEnumerable<Pet> pet)
        {
            var pets = pet.Select(x => new PetDetailViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner,
                FullData = "the pet's name is " + x.Name + ", it is " + x.Age + " years old, and the owner is " + x.Owner,
                Age = x.Age,
                RecommendedWeight = x.Age >= 0 ? 2 : x.Age > 1 ? 15 : x.Age > 2 ? 50 : 100,
            });

            return pets;
        }
    }
}
