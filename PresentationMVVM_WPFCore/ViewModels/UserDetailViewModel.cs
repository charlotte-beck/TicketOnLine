using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using Repositories;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class UserDetailViewModel : EntityViewModelBase<User>
    {
        #region Properties

        #endregion

        private UserRepository _userRepository;

        public UserDetailViewModel(User entity) : base(entity)
        {
            
        }

        public int UserId
        {
            get { return Entity.UserId; }
        }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete));
            }
        }
        private void Delete()
        {
            _userRepository.DeleteUser(UserId);
            //Messenger<DeleteEventMessage>.Instance.Send(new DeleteEventMessage(this));
        }

    }
}
