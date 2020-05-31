using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls.Primitives;
using Interfaces;
using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using PresentationMVVM_WPFCore.Views;
using Repositories;
using Repositories.Data;
using ToolBox.Patterns.Messenger;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class EventDetailViewModel : EntityViewModelBase<Event>
    {
        #region Properties
        private string _eventName;
        public string EventName
        {
            get { return _eventName; }
            set
            {
                if (_eventName != value)
                {
                    _eventName = value;
                    RaisePropertyChanged(nameof(EventName));
                }
            }
        }

        private string _eventType;
        public string EventType
        {
            get { return _eventType; }
            set
            {
                if (_eventType != value)
                {
                    _eventType = value;
                    RaisePropertyChanged(nameof(EventType));
                }
            }
        }
        private string _eventDescription;
        public string EventDescription
        {
            get { return _eventDescription; }
            set
            {
                if (_eventDescription != value)
                {
                    _eventDescription = value;
                    RaisePropertyChanged(nameof(EventDescription));
                }
            }
        }
        private string _eventOrg;
        public string EventOrg
        {
            get { return _eventOrg; }
            set
            {
                if (_eventOrg != value)
                {
                    _eventOrg = value;
                    RaisePropertyChanged(nameof(EventOrg));
                }
            }
        }
        private string _eventLocation;
        public string EventLocation
        {
            get { return _eventLocation; }
            set
            {
                if (_eventLocation != value)
                {
                    _eventLocation = value;
                    RaisePropertyChanged(nameof(EventLocation));
                }
            }
        }
        private DateTime _eventDate;
        public DateTime EventDate
        {
            get { return _eventDate; }
            set
            {
                if (_eventDate != value)
                {
                    _eventDate = value;
                    RaisePropertyChanged(nameof(EventDate));
                }
            }
        }
        private double _eventPrice;
        public double EventPrice
        {
            get { return _eventPrice; }
            set
            {
                if (_eventPrice != value)
                {
                    _eventPrice = value;
                    RaisePropertyChanged(nameof(EventPrice));
                }
            }
        }
        #endregion

        private EventRepository _eventRepository;
        public EventDetailViewModel(Event entity) : base(entity)
        {

            EventName = Entity.EventName;
            EventType = Entity.EventType;
            EventDescription = Entity.EventDescription;
            EventOrg = Entity.EventOrg;
            EventLocation = Entity.EventLocation;
            EventDate = Entity.EventDate;
            EventPrice = Entity.EventPrice;
            _eventRepository = new EventRepository("http://localhost:56586/api/");
        }
        public int EventId
        {
            get { return Entity.EventId; }
        }
        #region Update Command

        private RelayCommand _updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(UpdateEvent, CanUpdate));
            }
        }
        public bool CanUpdate()
        {
            return EventName != Entity.EventName
                || EventType != Entity.EventType
                || EventDescription != Entity.EventDescription
                || EventOrg != Entity.EventOrg
                || EventLocation != Entity.EventLocation
                || EventDate != Entity.EventDate
                || EventPrice != Entity.EventPrice;
        }
        public void UpdateEvent()
        {
            string oldName = Entity.EventName;
            string oldType = Entity.EventType;
            string oldDescription = Entity.EventDescription;
            string oldOrg = Entity.EventOrg;
            string oldLocation = Entity.EventLocation;
            DateTime oldDate = Entity.EventDate;
            double oldPrice = Entity.EventPrice;

            Entity.EventName = EventName;
            Entity.EventType = EventType;
            Entity.EventDescription = EventDescription;
            Entity.EventOrg = EventOrg;
            Entity.EventLocation = EventLocation;
            Entity.EventDate = EventDate;
            Entity.EventPrice = EventPrice;

            if (!_eventRepository.UpdateEvent(EventId, Entity))
            {
                Entity.EventName = oldName;
                Entity.EventType = oldType;
                Entity.EventDescription = oldDescription;
                Entity.EventOrg = oldOrg;
                Entity.EventLocation = oldLocation;
                Entity.EventDate = oldDate;
                Entity.EventPrice = oldPrice;
            }
        }
        #endregion
        #region Command    

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete));
            }
        }
        private void Delete()
        {
            _eventRepository.DeleteEvent(EventId);
            Messenger<Event>.Instance.Send(Entity);
        }

        private RelayCommand _detailsCommand;
        public RelayCommand DetailsCommand
        {
            get
            {
                return _detailsCommand ?? (_detailsCommand = new RelayCommand(ShowDetails));
            }
        }
        private void ShowDetails()
        {
            _eventRepository.GetOneEvent(EventId);
        }        
        #endregion
    }
}