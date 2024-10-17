namespace InterfaceAdapters.Models.Sales
{
    public class SaleModel
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ConceptModel> Concepts { get; set; }
    }
}
