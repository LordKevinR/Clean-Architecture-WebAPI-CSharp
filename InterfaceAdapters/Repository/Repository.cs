using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.Data;
using InterfaceAdapters.Models;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Repository
{
    public class Repository : IRepository<Pet>
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Pet pet)
        {
            var petModel = new PetModel()
            {
                Name = pet.Name,
                Owner = pet.Owner,
                Age = pet.Age,
            };

            await context.Pets.AddAsync(petModel);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await context.Pets
                .Select(pet => new Pet { Id = pet.Id, Name = pet.Name, Age = pet.Age, Owner = pet.Owner })
                .ToListAsync();
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            var pet = await context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            return new Pet { Id = pet.Id, Name = pet.Name, Age = pet.Age, Owner = pet.Owner };
        }
    }
}
