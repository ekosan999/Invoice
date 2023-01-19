using Invoice.Models;

namespace Invoice.Dtos.Products
{
    public class ProductCreateDto
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MaxDiscount { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
