using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb_ASPCore.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public DateTime FactureDate { get; set; }
        public int NbTicket { get; set; }
        public double FactureTotal { get; set; }
        public int NumTransactionValidee { get; set; }
        public int EventId { get; set; }
    }
}
