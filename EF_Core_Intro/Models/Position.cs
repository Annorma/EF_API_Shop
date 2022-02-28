using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    [Table("Positions")]
    public class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }
}
