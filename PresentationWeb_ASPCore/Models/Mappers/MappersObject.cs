using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D = Repositories.Data;

namespace PresentationWeb_ASPCore.Models.Mappers
{
    public static class MappersObject
    {
        public static User ToWeb(this D.User user)
        {
            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        public static Reservation_User_Event ToWeb(this D.Reservation_User_Event r)
        {
            return new Reservation_User_Event
            {
                FactureDate = r.FactureDate,
                NbTicket = r.NbTicket,
                FactureTotal = r.FactureTotal,
                NumTransactionValidee = r.NumTransactionValidee,
                Event = r.Event,
                User = r.User
            };
        }
    }
}
