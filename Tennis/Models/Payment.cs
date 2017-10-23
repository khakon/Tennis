using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class Payment: Item
    {
        public long Date { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Total { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int TrenerId { get; set; }
        public virtual Trener Trener { get; set; }
    }
}
