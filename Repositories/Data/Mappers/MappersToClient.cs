﻿using System;
using System.Collections.Generic;
using System.Text;
using G = Global;

namespace Repositories.Data.Mappers
{
    public static class MappersToClient
    {
        internal static Event ToClient(this G.Event e)
        {
            return new Event
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

        internal static User ToClient(this G.User u)
        {
            return new User(u.UserId, u.FirstName, u.LastName, u.Email, u.Passwd, u.IsActive, u.IsAdmin);
        }
    }
}
