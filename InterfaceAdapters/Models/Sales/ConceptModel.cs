using InterfaceAdapters.Models.Pets;

namespace InterfaceAdapters.Models.Sales
{
    public class ConceptModel
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int SaleId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        //navegation property
        public PetModel Pet { get; set; }
    }
}
