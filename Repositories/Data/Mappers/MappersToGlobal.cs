using g = Global;
using System;
using System.Collections.Generic;
using System.Text;
using Global;

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

        internal static g.User ToGlobal(this User u)
        {
            return new g.User
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Passwd = u.Passwd,
                IsActive = u.IsActive,
                IsAdmin = u.IsAdmin
            };
        }

        internal static g.Reservation ToGlobal(this Reservation r)
        {
            return new g.Reservation
            {
                ReservationId = r.ReservationId,
                UserId = r.UserId,
                EventId = r.EventId,
                FactureDate = r.FactureDate,
                NbTicket = r.NbTicket,
                FactureTotal = r.FactureTotal,
                NumTransactionValidee = r.NumTransactionValidee
            };
        }
    }
}
