using PresentationMVVM_WPFCore.Utils.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels.ViewModelsBase
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public ViewModelBase()
        {
            Type TViewModel = GetType();

            IEnumerable<PropertyInfo> commandes = TViewModel.GetProperties().Where(pi => pi.PropertyType == typeof(ICommand) || pi.PropertyType.GetInterfaces().Contains(typeof(ICommand)));

            foreach (PropertyInfo propertyInfo in commandes)
            {
                ICommand commande = (ICommand)propertyInfo.GetMethod.Invoke(this, null);
                PropertyChanged += (s, e) => commande.RaiseCanExecuteChanged();
            }
        }

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
