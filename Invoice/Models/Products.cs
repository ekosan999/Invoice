using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class Products : Audit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int MaxDiscount { get; set; }
        public int Quantity { get; set; }
        public Categories Category { get; set; }
    }
}
