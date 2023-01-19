using Invoice.Dtos.InvoiceDetails;
using Invoice.Dtos.Products;

namespace Invoice.Dtos.Billing
{
    public class InvoiceViewDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<InvoiceDetailsViewDto> InvoiceDetails { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
