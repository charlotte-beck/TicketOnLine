using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels.ViewModelsBase
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
