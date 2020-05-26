using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.Utils.Command
{
    public interface ICommand : System.Windows.Input.ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
