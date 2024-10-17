namespace InterfaceAdapters.DTOs.Sales
{
    public class SaleRequestDTO
    {
        public List<ConceptRequestDTO> Concepts { get; set; }
    }

    public class ConceptRequestDTO
    {
        public int PetId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
