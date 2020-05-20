using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.Utils.Messages;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using PresentationMVVM_WPFCore.Views;
using Repositories;
using Repositories.Data;
using ToolBox.Patterns.Messenger;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class EventDetailViewModel : ViewModelBase
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
        private Event _entity;
        private EventRepository _eventRepository;
        public EventDetailViewModel(Event entity)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        #region Command
        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(Add));
            }
        }
        private void Add()
        {
            Event e = new Event
            {
                EventType = _entity.EventType,
                EventName = _entity.EventName,
                EventDescription = _entity.EventDescription,
                EventOrg = _entity.EventOrg,
                EventLocation = _entity.EventLocation,
                EventDate = _entity.EventDate,
                EventPrice = _entity.EventPrice
            };
            _eventRepository.CreateEvent(e);
        }

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
            _eventRepository.DeleteEvent(_entity.EventId);
            //Messenger<DeleteEventMessage>.Instance.Send(new DeleteEventMessage());
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
            _eventRepository.GetOneEvent(_entity.EventId);
        }

        //public void Details()
        //{
        //    EventDetailsWindow dw = new EventDetailsWindow();
        //    dw.DataContext = this;

        //    dw.Show();
        //}

        private RelayCommand _updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(UpdateEvent));
            }
        }
        public void UpdateEvent()
        {
            _eventRepository.UpdateEvent(_entity.EventId, _entity);
        }
        #endregion
    }
}