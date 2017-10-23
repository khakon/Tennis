using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class Price : Item
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public decimal PriceDay { get; set; }
        public decimal PriceNight { get; set; }
        public int CountPlayer { get; set; }
    }
}
