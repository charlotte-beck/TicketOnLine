using g = Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using d = Repositories.Data;

namespace Api_ASPCore.Models.Mappers
{
    public static class MappersToGlobal
    {
        public static g.Event ToGlobal(this d.Event e)
        {
            return new g.Event
            {
                EventId = e.EventId,
                EventType = e.EventType,
                EventName = e.EventName,
                EventDescription = e.EventDescription,
                EventOrg = e.EventOrg,
                EventDate = e.EventDate,
                EventLocation = e.EventLocation,
                EventPrice = e.EventPrice
            };
        }

        public static g.User ToGlobal(this d.User du)
        {
            return new g.User
            {
                LastName = du.LastName,
                FirstName = du.FirstName,
                Email = du.Email,
                Passwd = du.Passwd
            };
        }
    }
}
