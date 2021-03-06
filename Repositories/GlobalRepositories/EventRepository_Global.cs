﻿using Global;
using Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repositories.GlobalRepositories
{
    public class EventRepository_Global : IEventRepository<Event>
    {
        #region Connexion
        private static IEventRepository<Event> _instance;
        public static IEventRepository<Event> Instance
        {
            get
            {
                return _instance ?? (_instance = new EventRepository_Global());
            }
        }


        //private readonly IConfiguration _configuration;
        //public static string myConnString;
        //public EventRepository_Global(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    myConnString = _configuration.GetConnectionString("myDb1");
        //    //_connection = new SqlConnection(@"Data Source=FORMA-VDI1106\TFTIC;Initial Catalog=DatabaseTicketOnLine;Integrated Security=True");
        //    //_connection = new SqlConnection(
        //    //    ConfigurationManager.ConnectionStrings["DatabaseTicketOnLine"].ConnectionString;
        //    _connection.Open();
        //}
        private SqlConnection _connection;
        public EventRepository_Global()
        {
            _connection = new SqlConnection(@"Data Source=FORMA-VDI1106\TFTIC;Initial Catalog=DatabaseTicketOnLine;Integrated Security=True");
            //_connection = new SqlConnection(
            //    ConfigurationManager.ConnectionStrings["DatabaseTicketOnLine"].ConnectionString;
            _connection.Open();
        }


        #endregion

        #region Create, Update, Delete Event WPF 
        public void CreateEvent(Event entity)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_CreateEvent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("EventName", entity.EventName);
            command.Parameters.AddWithValue("EventType", entity.EventType);
            command.Parameters.AddWithValue("EventDescription", entity.EventDescription);
            command.Parameters.AddWithValue("EventOrg", entity.EventOrg);
            command.Parameters.AddWithValue("EventDate", entity.EventDate);
            command.Parameters.AddWithValue("EventLocation", entity.EventLocation);
            command.Parameters.AddWithValue("EventPrice", entity.EventPrice);
            //entity.EventId = (int)command.ExecuteScalar();
            //return entity;
            command.ExecuteNonQuery();

        }

        public void UpdateEvent(int eventId, Event entity)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_UpdateEvent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("EventId", eventId);
            command.Parameters.AddWithValue("EventName", entity.EventName);
            command.Parameters.AddWithValue("EventType", entity.EventType);
            command.Parameters.AddWithValue("EventDescription", entity.EventDescription);
            command.Parameters.AddWithValue("EventOrg", entity.EventOrg);
            command.Parameters.AddWithValue("EventDate", entity.EventDate);
            command.Parameters.AddWithValue("EventLocation", entity.EventLocation);
            command.Parameters.AddWithValue("EventPrice", entity.EventPrice);
            command.ExecuteNonQuery();
        }

        public void DeleteEvent(int eventId)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_DeleteEvent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("EventId", eventId);
            command.ExecuteNonQuery();
        }
        #endregion

        #region Get Event ASP et WPF
        public List<Event> GetAllEvent()
        {
            List<Event> events = new List<Event>();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_GetEvents";
            command.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    events.Add(new Event
                    {
                        EventId = (int)dr["EventId"],
                        EventType = dr["EventType"].ToString(),
                        EventName = dr["EventName"].ToString(),
                        EventDescription = dr["EventDescription"].ToString(),
                        EventDate = (DateTime)dr["EventDate"],
                        EventOrg = dr["EventOrg"].ToString(),
                        EventLocation = dr["EventLocation"].ToString(),
                        EventPrice = (double)dr["EventPrice"]

                    });
                }
            }
            return events;
        }

        public Event GetOneEvent(int eventId)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SP_GetEvent";
            command.CommandType = CommandType.StoredProcedure;
            Event e = new Event();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    e.EventId = (int)dr["EventId"];
                    e.EventType = dr["EventType"].ToString();
                    e.EventName = dr["EventName"].ToString();
                    e.EventDescription = dr["EventDescription"].ToString();
                    e.EventOrg = dr["EventOrg"].ToString();
                    e.EventDate = (DateTime)dr["EventDate"];
                    e.EventLocation = dr["EventLocation"].ToString();
                    e.EventPrice = (double)dr["EventPrice"];
                }
            }
            return e;
        }
        #endregion

        #region Get EventByUser ASP
        public List<Event> GetAllByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Event GetOneByUser(int userId, int eventId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}