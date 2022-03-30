using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDbApp
{
    // Entity
    [Table("Cities")]
    public class City
    {
        public City()
        {
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
