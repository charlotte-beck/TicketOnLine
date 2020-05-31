using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Models
{
    public class UpdateEvent
    {
        public int EventId { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventOrg { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventDate { get; set; }
        public double EventPrice { get; set; }
    }
}
