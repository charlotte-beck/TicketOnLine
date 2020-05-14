using g = Global;
using d = Api_ASPCore.Models.Data;
using f = Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_ASPCore.Models.Data;
using Global;

namespace Api_ASPCore.Models.Mappers
{
    public static class MappersAPI
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

        public static d.Event ToLocal(this g.Event e)
        {
            return new d.Event
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

        public static d.User ToLocal(this g.User u)
        {
            return new d.User
            {
                LastName = u.LastName,
                FirstName = u.FirstName,
                Email = u.Email,
                Passwd = u.Passwd
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