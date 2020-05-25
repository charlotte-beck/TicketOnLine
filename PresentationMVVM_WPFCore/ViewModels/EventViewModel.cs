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
        private EventRepository _eventRepository;
        private Event _entity;

        public EventViewModel()
        {
            _eventRepository = new EventRepository("https://localhost:5001/api/");
            Messenger<EventDetailViewModel>.Instance.Register("EventDelete", OnDeleteEvent);
        }
        private void OnDeleteEvent(EventDetailViewModel instance)
        {
            Items.Remove(instance);
        }

        protected override ObservableCollection<EventDetailViewModel> LoadItems()
        {
            ObservableCollection<EventDetailViewModel> events =
                new ObservableCollection<EventDetailViewModel>(_eventRepository.GetAllEvent()
                .Select(x => new EventDetailViewModel(x)));
            return events;
        }

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
            addEventWindow.DataContext = this;
            addEventWindow.Show();
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(Add,CanAdd));
            }
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(_entity.EventName)
                && !string.IsNullOrWhiteSpace(_entity.EventType)
                && !string.IsNullOrWhiteSpace(_entity.EventDescription)
                && !string.IsNullOrWhiteSpace(_entity.EventOrg)
                && !string.IsNullOrWhiteSpace(_entity.EventLocation)
                && !string.IsNullOrWhiteSpace(_entity.EventDate.ToString())
                && !string.IsNullOrWhiteSpace(_entity.EventPrice.ToString());
        }

        private void Add()
        {
            Event e = new Event
            {
                EventName = _entity.EventName,
                EventType = _entity.EventType,
                EventDescription = _entity.EventDescription,
                EventOrg = _entity.EventOrg,
                EventLocation = _entity.EventLocation,
                EventDate = _entity.EventDate,
                EventPrice = _entity.EventPrice
            };
            _eventRepository.CreateEvent(e);
            Items.Add(new EventDetailViewModel(e));
        }
    }
}
