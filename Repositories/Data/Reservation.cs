using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Data
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime FactureDate { get; set; }
        public double FactureTotal { get; set; }
        public int NumTransactionValidee { get; set; }  
    }
}
