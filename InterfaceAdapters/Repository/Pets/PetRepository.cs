using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.Data;
using InterfaceAdapters.Models.Pets;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Repository.Pets
{
    public class PetRepository : IRepository<Pet>
    {
        private readonly ApplicationDbContext context;

        public PetRepository(ApplicationDbContext context)
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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            var pet = await context.Pets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (pet is null)
                throw new NotFoundValidationException($"A pet with the id {id} does not exist");

            return new Pet { Id = pet.Id, Name = pet.Name, Age = pet.Age, Owner = pet.Owner };
        }

        public async Task DeleteAsync(int id)
        {
            var pet = await GetByIdAsync(id);
            await context.Pets.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task UpdateAsync(int id, Pet generic)
        {
            var pet = await context.Pets.FirstOrDefaultAsync(x => x.Id == id);

            if (pet is null)
                throw new NotFoundValidationException($"A pet with the id {id} does not exist");

            pet.Name = generic.Name;
            pet.Age = generic.Age;
            pet.Owner = generic.Owner;

            context.Pets.Update(pet);
            await context.SaveChangesAsync();
        }
    }
}
