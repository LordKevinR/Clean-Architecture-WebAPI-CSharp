using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAdapters.Presenters
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
