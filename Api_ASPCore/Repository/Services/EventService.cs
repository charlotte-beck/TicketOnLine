using Api_ASPCore.Models.Data;
using Api_ASPCore.Models.Mappers;
using Interfaces;
using Repositories.GlobalRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Repository.Services
{
    public class EventService : IEventRepository<Event>
    {
        private static IEventRepository<Event> _instance;
        public static IEventRepository<Event> Instance
        {
            get { return _instance ?? (_instance = new EventService()); }
        }

        public void CreateEvent(Event entity)
        {
            EventRepository_Global.Instance.CreateEvent(entity.ToGlobal());
        }

        public void DeleteEvent(int eventId)
        {
            EventRepository_Global.Instance.DeleteEvent(eventId);
        }

        public List<Event> GetAllByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEvent()
        {
            return EventRepository_Global.Instance.GetAllEvent().Select(ev => ev.ToLocal()).ToList();
        }

        public Event GetOneByUser(int userId, int eventId)
        {
            throw new NotImplementedException();
        }

        public Event GetOneEvent(int eventId)
        {
            return EventRepository_Global.Instance.GetOneEvent(eventId).ToLocal();
        }

        public void UpdateEvent(int eventId, Event entity)
        {
            EventRepository_Global.Instance.UpdateEvent(eventId, entity.ToGlobal());
        }
    }
}