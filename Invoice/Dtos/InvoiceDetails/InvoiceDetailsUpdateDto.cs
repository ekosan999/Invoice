namespace Invoice.Dtos.InvoiceDetails
{
    public class InvoiceDetailsUpdateDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
    }
}
