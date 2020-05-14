using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels.ViewModelsBase
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
