using Interfaces;
using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.Utils.Messages;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
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
            _eventRepository = new EventRepository(https://localhost:5001/);
        }

        protected override ObservableCollection<EventDetailViewModel> LoadItems()
        {
            ObservableCollection<EventDetailViewModel> events =
                new ObservableCollection<EventDetailViewModel>(_eventRepository.GetAllEvent()
                .Select(x => new EventDetailViewModel(x)));
            return events;
        }
    }
}
