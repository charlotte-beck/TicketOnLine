using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using PresentationMVVM_WPFCore.Views;
using Repositories;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class AddEventViewModel : ViewModelBase
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


        public AddEventViewModel()
        {
            _eventRepository = new EventRepository("https://localhost:5001/api/");

        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(Add, CanAdd));
            }
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(EventName)
                && !string.IsNullOrWhiteSpace(EventType)
                && !string.IsNullOrWhiteSpace(EventDescription)
                && !string.IsNullOrWhiteSpace(EventOrg)
                && !string.IsNullOrWhiteSpace(EventLocation)
                && !string.IsNullOrEmpty(EventDate.ToString())
                && !string.IsNullOrWhiteSpace(EventPrice.ToString());
        }

        private void Add()
        {
            Event e = new Event
            {
                EventName = EventName,
                EventType = EventType,
                EventDescription = EventDescription,
                EventOrg = EventOrg,
                EventLocation = EventLocation,
                EventDate = EventDate,
                EventPrice = EventPrice
            };
            _eventRepository.CreateEvent(e);
            //Items.Add(new EventDetailViewModel(e));
        }
    }
}