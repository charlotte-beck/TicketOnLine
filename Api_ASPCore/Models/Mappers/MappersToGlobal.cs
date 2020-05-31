using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Models.Mappers
{
    public static class MappersToGlobal
    {
        public static Event ToGlobal(this CreateEvent ce)
        {
            return new Event
            {
                EventId = ce.EventId,
                EventType = ce.EventType,
                EventName = ce.EventName,
                EventDescription = ce.EventDescription,
                EventOrg = ce.EventOrg,
                EventDate = ce.EventDate,
                EventLocation = ce.EventLocation,
                EventPrice = ce.EventPrice
            };
        }

        public static Event ToGlobal(this UpdateEvent ue)
        {
            return new Event
            {
                EventId = ue.EventId,
                EventType = ue.EventType,
                EventName = ue.EventName,
                EventDescription = ue.EventDescription,
                EventOrg = ue.EventOrg,
                EventDate = ue.EventDate,
                EventLocation = ue.EventLocation,
                EventPrice = ue.EventPrice
            };
        }

        public static User ToGlobal(this RegisterForm rf)
        {
            return new User
            {
                LastName = rf.LastName,
                FirstName = rf.FirstName,
                Email = rf.Email,
                Passwd = rf.Passwd
            };
        }

        public static User ToGlobal(this LoginForm lf)
        {
            return new User
            {
                Email = lf.Email,
                Passwd = lf.Passwd
            };
        }
    }
}
