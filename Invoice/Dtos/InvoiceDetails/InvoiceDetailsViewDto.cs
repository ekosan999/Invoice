using Invoice.Dtos.Products;

namespace Invoice.Dtos.InvoiceDetails
{
    public class InvoiceDetailsViewDto
    {
        public int Id { get; set; }
//       public int InvoicesId { get; set; }
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }


    }
}
