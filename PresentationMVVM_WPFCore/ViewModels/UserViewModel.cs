using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using Repositories;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ToolBox.Patterns.Messenger;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class UserViewModel : ViewModelCollectionBase<UserDetailViewModel>
    {
        private UserRepository _userRepository;
        private User _entity;

        public UserViewModel()
        {
            _userRepository = new UserRepository("http://localhost:56586/api/");
            Messenger<User>.Instance.Register(OnDeleteUser);
        }
        private void OnDeleteUser(User u)
        {
            UserDetailViewModel userDetailViewModel = new UserDetailViewModel(u);
            Items = LoadItems();
        }

        protected override ObservableCollection<UserDetailViewModel> LoadItems()
        {
            ObservableCollection<UserDetailViewModel> users =
                new ObservableCollection<UserDetailViewModel>(_userRepository.GetAllUser()
                .Select(x => new UserDetailViewModel(x)));
            return users;
        }
    }

}
