using Invoice.Dtos.InvoiceDetails;

namespace Invoice.Dtos.Billing
{
    public class InvoiceCreateDto
    {
        public string Description { get; set; }
        public List<InvoiceDetailCreateDto> InvoiceDetails { get; set; }
    }

}
