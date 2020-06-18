using System;
using System.Collections.Generic;
using System.Text;
using G = Global;

namespace Repositories.Data.Mappers
{
    public static class MappersToClient
    {
        public static Event ToClient(this G.Event e)
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

        public static User ToClient(this G.User u)
        {
            return new User(u.UserId, u.FirstName, u.LastName, u.Email, u.Passwd, u.IsAdmin, u.IsActive, u.Token);
        }

        public static Reservation ToClient(this G.Reservation r)
        {
            return new Reservation
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

        public static Reservation_User_Event ToClient(this G.Reservation_User_Event r)
        {
            return new Reservation_User_Event
            {
                ReservationId = r.ReservationId,
                UserId = r.UserId,
                EventId = r.EventId,
                FactureDate = r.FactureDate,
                NbTicket = r.NbTicket,
                FactureTotal = r.FactureTotal,
                NumTransactionValidee = r.NumTransactionValidee,
                User = r.User,
                Event = r.Event
            };
        }

        public static Comment ToClient(this G.Comment c)
        {
            return new Comment
            {
                CommentId = c.CommentId,
                UserId = c.UserId,
                EventId = c.EventId,
                CommentDate = c.CommentDate,
                CommentContent = c.CommentContent
            };
        }

        public static Comment_User_Event ToClient(this G.Comment_User_Event c)
        {
            return new Comment_User_Event
            {
                CommentId = c.CommentId,
                UserId = c.UserId,
                EventId = c.EventId,
                CommentDate = c.CommentDate,
                CommentContent = c.CommentContent,
                User = c.User,
                Event = c.Event
            };
        }
    }
}
