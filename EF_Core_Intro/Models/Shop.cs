using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    [Table("Shops")]
    public class Shop
    {
        public Shop()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        // Navigation Properties
        [Required, MaxLength(20)]
        public int ParkingArea { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }
}
