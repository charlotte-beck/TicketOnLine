using PresentationMVVM_WPFCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.Utils.Messages
{
    public class DeleteEventMessage
    {
        public EventDetailViewModel ViewModel { get; private set; }

        public DeleteEventMessage(EventDetailViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
