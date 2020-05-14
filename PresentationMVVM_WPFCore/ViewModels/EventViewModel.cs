using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
        #endregion
        protected override ObservableCollection<EventDetailViewModel> LoadItems()
        {
            throw new NotImplementedException();
        }
    }
}
