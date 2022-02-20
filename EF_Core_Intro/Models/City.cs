﻿using System;
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
            Positions = new HashSet<Position>();
        }
        // Properties (columns in db)
        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }
        [Required]          // set not null
        [MaxLength(100)]    // set max length NVarChar(100)
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }

        // Navigation Properties

        // Relationship Type: 1...* (One to Many)
        [Required]
        public Department Department { get; set; }
        // Relationship Type: 0/1...* (Zero or One to Many)
        public Country Country { get; set; }
        // Relationship Type: *...* (Many to Many)
        public ICollection<Position> Positions { get; set; }
    }
}
