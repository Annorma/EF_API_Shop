using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDbApp
{
    [Table("Shops")]
    public class Shop
    {
        public Shop()
        {
            Workers = new HashSet<Worker>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, MaxLength(20)]
        public int? ParkingArea { get; set; }

        public City City { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
