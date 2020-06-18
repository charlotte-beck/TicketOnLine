using Interfaces;
using PresentationMVVM_WPFCore.Utils.Command;
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
        public EventViewModel()
        {
            _eventRepository = new EventRepository("http://localhost:56586/api/");
            Messenger<Event>.Instance.Register(OnDeleteEvent);
            Messenger<Event>.Instance.Register(OnAddEvent);
        }
        private void OnDeleteEvent(Event e)
        {
            EventDetailViewModel eventDetailViewModel = new EventDetailViewModel(e);
            Items = LoadItems();
        }

        private void OnAddEvent(Event e)
        {
            EventViewModel eventViewModel = new EventViewModel();
            Items = LoadItems();
        }

        protected override ObservableCollection<EventDetailViewModel> LoadItems()
        {
            ObservableCollection<EventDetailViewModel> events =
                new ObservableCollection<EventDetailViewModel>(_eventRepository.GetAllEvent()
                .Select(x => new EventDetailViewModel(x)));
            return events;
        }

        #region Redirect to AddEvent Command

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
        #endregion
    }
}
