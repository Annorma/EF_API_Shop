using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    // Entity
    [Table("Cities")]
    public class City
    {
        public City()
        {
            Shops = new HashSet<Shop>();
        }
        // Properties (columns in db)
        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }
        [Required]          // set not null
        [MaxLength(100)]    // set max length NVarChar(100)
        public string Name { get; set; }

        // Navigation Properties
        [Required]
        public Country Country { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
