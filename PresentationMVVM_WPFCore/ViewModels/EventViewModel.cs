using Interfaces;
using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.Utils.Messages;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using PresentationMVVM_WPFCore.Views;
using Repositories;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ToolBox.Patterns.Messenger;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class EventViewModel : ViewModelCollectionBase<EventDetailViewModel>
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
        public int EventId
        {
            get { return _entity.EventId; }
        }
        #endregion

        private EventRepository _eventRepository;
        private Event _entity;

        public EventViewModel()
        {
            _eventRepository = new EventRepository("https://localhost:5001/api/");
            //Messenger<EventDetailViewModel>.Instance.Register("EventDelete", OnDeleteEvent);
        }
        //private void OnDeleteEvent(EventDetailViewModel instance)
        //{
        //    Items.Remove(instance);
        //}

        //protected override ObservableCollection<EventDetailViewModel> LoadItems()
        //{
        //    ObservableCollection<EventDetailViewModel> events =
        //        new ObservableCollection<EventDetailViewModel>(_eventRepository.GetAllEvent()
        //        .Select(x => new EventDetailViewModel(x)));
        //    return events;
        //}

        //private RelayCommand _updateCommand;
        //public RelayCommand UpdateCommand
        //{
        //    get
        //    {
        //        return _updateCommand ?? (_updateCommand = new RelayCommand(UpdateEvent, CanUpdate));
        //    }
        //}
        //public bool CanUpdate()
        //{
        //    return EventName != _entity.EventName
        //        || EventType !=_entity.EventType
        //        || EventDescription != _entity.EventDescription
        //        || EventOrg != _entity.EventOrg
        //        || EventLocation != _entity.EventLocation
        //        || EventDate != _entity.EventDate
        //        || EventPrice != _entity.EventPrice;
        //}
        //public void UpdateEvent()
        //{
        //    string oldName = _entity.EventName;
        //    string oldType = _entity.EventType;
        //    string oldDescription = _entity.EventDescription;
        //    string oldOrg = _entity.EventOrg;
        //    string oldLocation = _entity.EventLocation;
        //    DateTime oldDate = _entity.EventDate;
        //    double oldPrice = _entity.EventPrice;

        //    _entity.EventName = EventName;
        //    _entity.EventType = EventType;
        //    _entity.EventDescription = EventDescription;
        //    _entity.EventOrg = EventOrg;
        //    _entity.EventLocation = EventLocation;
        //    _entity.EventDate = EventDate;
        //    _entity.EventPrice = EventPrice;

        //    //if (!_eventRepository.UpdateEvent(EventId, _entity))
        //    //{
        //    //    _entity.EventName = oldName;
        //    //    _entity.EventType = oldType;
        //    //    _entity.EventDescription = oldDescription;
        //    //    _entity.EventOrg = oldOrg;
        //    //    _entity.EventLocation = oldLocation;
        //    //    _entity.EventDate = oldDate;
        //    //    _entity.EventPrice = oldPrice;
        //    //}
        //}

        private RelayCommand _toAddCommand;
        public RelayCommand ToAddCommand
        {
            get
            {
                return _toAddCommand ?? (_toAddCommand = new RelayCommand(GoToAddEventWindow));
            }
        }
        public void GoToAddEventWindow()
        {
            AddEventWindow addEventWindow = new AddEventWindow();
            //addEventWindow.DataContext = this;
            addEventWindow.Show();
        }

        
         
    }
}
