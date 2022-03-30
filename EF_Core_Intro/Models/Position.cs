using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDbApp
{
    [Table("Positions")]
    public class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }
}
