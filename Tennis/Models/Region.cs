using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class Region : Item
    {
        public Region()
        {
            Courts = new HashSet<Court>();
        }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Court> Courts { get; set; }
    }
}
