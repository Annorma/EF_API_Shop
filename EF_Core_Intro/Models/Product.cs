using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public float Discount { get; set; }

        [Required, MaxLength(10)]
        public int Quantity { get; set; }

        [Required]
        public bool IsInStock { get; set; }

        // Navigation Properties
        [Required]
        public Category CategoryId { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
