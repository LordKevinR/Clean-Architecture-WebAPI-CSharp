
namespace Domain.Entities
{
    public class Concept
    {
        public int PetId { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }
        public decimal Price { get; }
        public Concept(int quantity, int petId, decimal unitPrice)
        {
            Quantity = quantity;
            PetId = petId;
            UnitPrice = unitPrice;
            Price = GetTotalPrice();
        }

        private decimal GetTotalPrice()
            => Quantity * UnitPrice;
    }
}
