using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Intro
{
    public class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        
        //public string Description { get; set; }
        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }
}
