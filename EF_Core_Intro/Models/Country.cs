﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    [Table("Countries")]
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<City> Cities { get; set; }
    }
}
