using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Intro
{
    public class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }

        [Key]   // set primary key
        public int Number { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(40)]
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }
}
