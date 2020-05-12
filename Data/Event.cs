using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Event
    {
        public Event(int eventId, string eventType, string eventName, DateTime eventDate, string eventDescription, string eventOrg, string eventLocation, double eventPrice)
        {
            EventId = eventId;
            EventType = eventType;
            EventName = eventName;
            EventDate = eventDate;
            EventDescription = eventDescription;
            EventOrg = eventOrg;
            EventLocation = eventLocation;
            EventPrice = eventPrice;
        }
        #region fullprop??
        //private int _eventId;
        //private string _eventType, _eventName, _eventDescription, _eventOrg, _eventLocation;
        //private DateTime _eventDate;
        //private double _eventPrice;

        //public int EventId
        //{
        //    get { return _eventId; }
        //    private set { _eventId = value; }
        //}
        //public string EventType
        //{
        //    get { return _eventType; }
        //    set { _eventType = value; }
        //}
        //public string EventName
        //{
        //    get { return _eventName; }
        //    set { _eventName = value; }
        //}
        //public string EventDescription
        //{
        //    get { return _eventDescription; }
        //    set { _eventDescription = value; }
        //}
        //public string EventOrg
        //{
        //    get { return _eventOrg; }
        //    set { _eventOrg = value; }
        //}
        //public string EventLocation
        //{
        //    get { return _eventLocation; }
        //    set { _eventLocation = value; }
        //}
        //public DateTime EventDate
        //{
        //    get { return _eventDate; }
        //    set { _eventDate = value; }
        //}
        //public double EventPrice
        //{
        //    get { return _eventPrice; }
        //    set { _eventPrice = value; }
        //}

        //public Event(string eventType, string eventName, string eventLocation, DateTime eventDate, double eventPrice)
        //{
        //    EventType = eventType;
        //    EventName = eventName;
        //    EventLocation = eventLocation;
        //    EventDate = eventDate;
        //    EventPrice = eventPrice;
        //}
        //public Event()
        //{

        //}
        #endregion
        public int EventId { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventOrg { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventDate { get; set; }
        public double EventPrice { get; set; }
    }
}
