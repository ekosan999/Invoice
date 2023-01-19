using Invoice.Models;

namespace Invoice.Dtos.Products
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MaxDiscount { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
    }
}
