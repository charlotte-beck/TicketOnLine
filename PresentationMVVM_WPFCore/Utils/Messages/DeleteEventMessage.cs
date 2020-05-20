using PresentationMVVM_WPFCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.Utils.Messages
{
    public class DeleteEventMessage
    {
        public EventViewModel ViewModel { get; private set; }

        public DeleteEventMessage(EventViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
