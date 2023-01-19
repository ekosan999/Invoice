using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class Categories : Audit
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

    }
}
