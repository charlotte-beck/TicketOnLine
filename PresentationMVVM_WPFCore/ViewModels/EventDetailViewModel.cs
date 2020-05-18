using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using Repositories.Data;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class EventDetailViewModel : ViewModelBase
    {
        #region Properties

        #endregion
        private Event _entity;
        private IEventAPIRequester<Event> _eventRepository;
        public EventDetailViewModel(Event e)
        {
            _entity = e;
        }
        public EventDetailViewModel(IEventAPIRequester<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete));
            }
        }

        public void Delete()
        {
            _eventRepository.DeleteEvent(_entity.EventId);
            //Messenger
            //GestionEvent<Film>.Instance.Send(_entity);
        }

        private RelayCommand _detailsCommand;
        public RelayCommand DetailsCommand
        {
            get
            {
                return _detailsCommand ?? (_detailsCommand = new RelayCommand(Details));
            }
        }

        public void Details()
        {
            EventDetailsWindow dw = new EventDetailsWindow();
            dw.DataContext = this;

            dw.Show();
        }

    }
}
