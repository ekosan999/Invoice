using Invoice.Dtos.InvoiceDetails;

namespace Invoice.Dtos.Billing
{
    public class InvoiceUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InvoiceDetailsUpdateDto> InvoiceDetails { get; set; }

    }

}
