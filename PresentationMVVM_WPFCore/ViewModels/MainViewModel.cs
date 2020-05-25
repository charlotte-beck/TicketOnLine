using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class MainViewModel
    {
        //public void Details()
        //{
        //    EventDetailsWindow dw = new EventDetailsWindow();
        //    dw.DataContext = this;

        //    dw.Show();
        //}

        private RelayCommand _toEventCommand;
        public RelayCommand ToEventCommand
        {
            get
            {
                return _toEventCommand ?? (_toEventCommand = new RelayCommand(GoToEventSection));
            }
        }

        private RelayCommand _toUserCommand;
        public RelayCommand ToUserCommand
        {
            get
            {
                return _toUserCommand ?? (_toUserCommand = new RelayCommand(GoToUserSection));
            }
        }

        public void GoToUserSection()
        {
            UserWindow userWindow = new UserWindow();
            userWindow.DataContext = this;
            userWindow.Show();
        }

        public void GoToEventSection()
        {
            EventWindow eventWindow = new EventWindow();
            eventWindow.DataContext = this;
            eventWindow.Show();
        }
    }
}
