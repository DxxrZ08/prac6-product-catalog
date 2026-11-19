using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Product
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public string Category { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
    }
}
