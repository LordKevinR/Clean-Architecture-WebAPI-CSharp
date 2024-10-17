using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.DTOs.Sales;

namespace InterfaceAdapters.Mappers.Sales
{
    public class SaleMapper : IMapper<SaleRequestDTO, Sale>
    {
        public Sale ToEntity(SaleRequestDTO dto)
        {
            var concepts = new List<Concept>();

            foreach (var conceptDTO in dto.Concepts)
            {
                concepts.Add(new Concept(conceptDTO.Quantity, conceptDTO.PetId, conceptDTO.UnitPrice));
            }

            return new Sale (DateTime.Now, concepts);
        }
    }
}
