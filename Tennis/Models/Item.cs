using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
