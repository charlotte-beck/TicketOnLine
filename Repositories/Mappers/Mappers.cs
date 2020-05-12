using Data;
using System;
using System.Collections.Generic;
using System.Text;
using G = Global;

namespace Repositories.Mappers
{
    internal static class Mappers
    {
        internal static Event ToClient(this G.Event entity)
        {
            return new Event(entity.EventId, entity.EventType, entity.EventName, entity.EventDate, entity.EventDescription, entity.EventOrg, entity.EventLocation, entity.EventPrice);
        }
    }
}
