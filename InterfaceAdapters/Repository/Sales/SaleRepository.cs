using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.Data;
using InterfaceAdapters.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Repository.Sales
{
    public class SaleRepository : IRepository<Sale>
    {
        private readonly ApplicationDbContext context;

        public SaleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Sale sale)
        {
            try
            {
                // Extract unique PetIds from the concepts
                var petIds = sale.Concepts.Select(c => c.PetId).Distinct().ToList();

                // Check that all PetIds exist in the Pet table
                var existingPetIds = await context.Pets
                    .Where(p => petIds.Contains(p.Id))
                    .Select(p => p.Id)
                    .ToListAsync();

                if (existingPetIds.Count != petIds.Count)
                {
                    var missingIds = petIds.Except(existingPetIds);
                    throw new NotFoundValidationException(
                        $"The following pets do not exist: {string.Join(", ", missingIds)}"
                    );
                }

                // If all PetIds are valid, proceed to create the sale model
                var saleModel = new SaleModel
                {
                    Total = sale.Total,
                    CreationDate = sale.Date,
                    Concepts = sale.Concepts.Select(c => new ConceptModel
                    {
                        UnitPrice = c.UnitPrice,
                        Quantity = c.Quantity,
                        PetId = c.PetId
                    }).ToList()
                };

                await context.Sales.AddAsync(saleModel);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestValidationException(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await context.Sales
              .Select(s => new Sale(
                s.Id,
                s.CreationDate,
                context.Concepts
                    .Where(c => c.SaleId == s.Id)
                    .Select(c => new Concept(c.Quantity, c.PetId, c.UnitPrice))
                    .ToList()
              )).ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            var saleModel = await context.Sales.FindAsync(id);

            return new Sale(
                saleModel.Id,
                saleModel.CreationDate,
                context.Concepts
                    .Where(c => c.SaleId == saleModel.Id)
                    .Select(c => new Concept(c.Quantity, c.PetId, c.UnitPrice))
                    .ToList()
            );
        }

        public async Task UpdateAsync(int id, Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
