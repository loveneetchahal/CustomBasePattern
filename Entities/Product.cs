using System.ComponentModel.DataAnnotations;

namespace CustomBasePattern.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Price must be between 0.01 and 100000.")]
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}
