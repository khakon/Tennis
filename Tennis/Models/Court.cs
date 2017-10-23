using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class Court: Item
    {
        public Court()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public double Rating { get; set; }

        public int RegionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Image { get; set; }

        [Required]
        [StringLength(255)]
        public string Adress { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
