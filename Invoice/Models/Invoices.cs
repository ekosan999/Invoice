using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class Invoices : Audit
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
