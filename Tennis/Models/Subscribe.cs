using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public abstract class Subscribe : Item
    {
        public long TimeStamp { get; set; }

        public int ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
