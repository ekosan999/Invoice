namespace Invoice.Dtos.Billing
{
    public class InvoiceUpdateDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
    }

}
