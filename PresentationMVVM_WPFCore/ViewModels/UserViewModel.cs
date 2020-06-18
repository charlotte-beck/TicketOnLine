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
        #region Properties

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _passwd;
        public string Passwd
        {
            get { return _passwd; }
            set { _passwd = value; }
        }

        private string _token;
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private bool _isAdmin;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    RaisePropertyChanged(nameof(IsAdmin));
                }
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    RaisePropertyChanged(nameof(IsActive));
                }
            }
        }
        #endregion

        private UserRepository _userRepository;
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
