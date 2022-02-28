using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    [Table("Workers")]
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Product> Products { get; set; }
    }
}
