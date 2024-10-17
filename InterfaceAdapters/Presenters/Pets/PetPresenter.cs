using Application.Interfaces;
using Domain.Entities;

namespace InterfaceAdapters.Presenters.Pets
{
    public class PetPresenter : IPresenter<Pet, PetViewModel>
    {
        public IEnumerable<PetViewModel> Present(IEnumerable<Pet> data)
        {
            return data.Select(p => new PetViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Owner = p.Owner,
                FullData = "the pet's name is " + p.Name + ", it is " + p.Age + " years old, and the owner is " + p.Owner
            });
        }
    }
}
