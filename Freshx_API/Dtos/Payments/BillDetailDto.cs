namespace Freshx_API.Dtos.Payments
{
    public class BillDetailDto
    {
        public int ServiceCatalogId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

