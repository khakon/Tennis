using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class Timetable : Item
    {
        public Timetable()
        {
            Reservations = new HashSet<Reservation>();
        }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
