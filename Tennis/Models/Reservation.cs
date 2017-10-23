using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class Reservation : Item
    {
        public long Start { get; set; }
        public long Range { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CourtId { get; set; }
        public int PriceId { get; set; }
        public decimal Total { get; set; }
        public virtual Court Court { get; set; }
        public virtual Price Price { get; set; } 
    }
}
