using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class SubscribePlayer:Subscribe
    {
        public int PlayerId { get; set; }
        public bool Order { get; set; }
        public bool Skipping { get; set; }
        public virtual Player Player { get; set; }
    }
}
