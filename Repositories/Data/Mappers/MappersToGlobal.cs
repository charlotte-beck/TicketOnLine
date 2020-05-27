using g = Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Data.Mappers
{
    public static class MappersToGlobal
    {
        internal static g.Event ToGlobal(this Event e)
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
    }
}
