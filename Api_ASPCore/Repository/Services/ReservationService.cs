using Global;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Repository.Services
{
    public class ReservationService : IReservationRepository<Reservation, Reservation_User_Event>
    {
        private static IReservationRepository<Reservation, Reservation_User_Event> _instance;
        public static IReservationRepository<Reservation, Reservation_User_Event> Instance
        {
            get
            {
                return _instance ?? (_instance = new ReservationService());
            }
        }

        private SqlConnection _connection;
        public ReservationService()
        {
            _connection = new SqlConnection(@"Data Source=FORMA-VDI1106\TFTIC;Initial Catalog=DatabaseTicketOnLine;Integrated Security=True");
            _connection.Open();
        }

        public Reservation CreateReservation(Reservation entity)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_CreateReservation";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("FactureDate", entity.FactureDate);
            command.Parameters.AddWithValue("NbTicket", entity.NbTicket);
            command.Parameters.AddWithValue("FactureTotal", entity.FactureTotal);
            command.Parameters.AddWithValue("NumTransactionValidee", entity.NumTransactionValidee);
            command.Parameters.AddWithValue("UserId", entity.UserId);
            command.Parameters.AddWithValue("EventId", entity.EventId);

            command.ExecuteNonQuery();
            return entity;
        }

        public List<Reservation_User_Event> GetAllByUser(int userId)
        {
            List<Reservation_User_Event> reservations = new List<Reservation_User_Event>();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_GetAllReservation_User";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", userId);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    reservations.Add(new Reservation_User_Event
                    {
                        ReservationId = (int)dr["ReservationId"],
                        UserId = (int)dr["UserId"],
                        EventId = (int)dr["EventId"],
                        FactureDate = (DateTime)dr["FactureDate"],
                        NbTicket = (int)dr["NbTicket"],
                        FactureTotal = (double)dr["FactureTotal"],
                        User = (string)dr["User"],
                        Event = (string)dr["Event"]
                    });
                }
            }
            return reservations;
        }

        public List<Reservation_User_Event> GetAllByEvent(int eventId)
        {
            List<Reservation_User_Event> reservations = new List<Reservation_User_Event>();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_GetAllReservation_Event";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EventId", eventId);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    reservations.Add(new Reservation_User_Event
                    {
                        ReservationId = (int)dr["ReservationId"],
                        UserId = (int)dr["UserId"],
                        EventId = (int)dr["EventId"],
                        FactureDate = (DateTime)dr["FactureDate"],
                        NbTicket = (int)dr["NbTicket"],
                        FactureTotal = (double)dr["FactureTotal"],
                        User = (string)dr["User"],
                        Event = (string)dr["Event"]
                    });
                }
            }
            return reservations;
        }

        public Reservation_User_Event GetOneReservation(int reservationId)
        {
            Reservation_User_Event reservation = new Reservation_User_Event();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_GetOneReservation";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ReservationId", reservationId);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    reservation.ReservationId = (int)dr["ReservationId"];
                    reservation.UserId = (int)dr["UserId"];
                    reservation.EventId = (int)dr["EventId"];
                    reservation.FactureDate = (DateTime)dr["FactureDate"];
                    reservation.NbTicket = (int)dr["NbTicket"];
                    reservation.FactureTotal = (double)dr["FactureTotal"];
                    reservation.User = (string)dr["User"];
                    reservation.Event = (string)dr["Event"];
                }
            }
            return reservation;
        }
    }
}
