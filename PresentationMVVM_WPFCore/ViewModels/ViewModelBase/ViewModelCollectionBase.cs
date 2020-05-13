using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels.ViewModelBase
{
    public abstract class ViewModelCollectionBase<TViewModel> : ViewModelBase
        where TViewModel : ViewModelBase
    {
        private ObservableCollection<TViewModel> _viewModels;
        public ObservableCollection<TViewModel> ViewModels
        {
            get
            {
                return _viewModels ?? (_viewModels = LoadItems());
            }
            set
            {
                if (_viewModels != value)
                {
                    _viewModels = value;
                    RaisePropertyChanged(nameof(ViewModels));
                }
            }
        }

        private TViewModel _selection;
        public TViewModel Selection
        {
            get
            {
                return _selection;
            }

            set
            {
                if (_selection != value)
                {
                    _selection = value;
                    RaisePropertyChanged(nameof(Selection));
                }
            }
        }

        protected abstract ObservableCollection<TViewModel> LoadItems();
    }
}
