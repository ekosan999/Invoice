using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class InvoiceDetail : Audit
    {
        [Key]
        public int Id { get; set; }
        public int InvoicesId { get; set; }
        public int ProductsId { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
