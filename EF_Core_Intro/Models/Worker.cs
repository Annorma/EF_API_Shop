using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    // Entity
    [Table("Workers")]
    public class Worker
    {
        // Properties (columns in db)
        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }

        [Required]          // set not null
        [MaxLength(100)]    // set max length NVarChar(100)
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Surname { get; set; }
        public decimal Salary { get; set; }

        [Required, MaxLength(70)]
        public string Email { get; set; }

        [MaxLength(40)]
        public string PhoneNumber { get; set; }


        // Navigation Properties

        [Required]
        public Position Position { get; set; }
        [Required]
        public Shop ShopId { get; set; }

    }
}
