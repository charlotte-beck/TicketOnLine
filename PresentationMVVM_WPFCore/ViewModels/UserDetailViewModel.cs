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
        public int UserId
        {
            get { return Entity.UserId; }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged(nameof(FirstName));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged(nameof(LastName));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    RaisePropertyChanged(nameof(Email));
                }
            }
        }

        private string _passwd;
        public string Passwd
        {
            get { return _passwd; }
            set
            {
                if (_passwd != value)
                {
                    _passwd = value;
                    RaisePropertyChanged(nameof(Passwd));
                }
            }
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

        public UserDetailViewModel(User entity) : base(entity)
        {
            _userRepository = new UserRepository("http://localhost:56586/api/");
        }

        #region Command

        //private RelayCommand _deleteCommand;
        //public RelayCommand DeleteCommand
        //{
        //    get
        //    {
        //        return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete));
        //    }
        //}
        //private void Delete()
        //{
        //    _userRepository.DeleteUser(UserId);
        //    //Messenger<DeleteEventMessage>.Instance.Send(new DeleteEventMessage(this));
        //}

        private RelayCommand _detailsCommand;
        public RelayCommand DetailsCommand
        {
            get
            {
                return _detailsCommand ?? (_detailsCommand = new RelayCommand(ShowDetails));
            }
        }
        private void ShowDetails()
        {
            _userRepository.GetOneUser(UserId);
        }
        #endregion

        #region Update Command

        private RelayCommand _updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(UpdateUser, CanUpdate));
            }
        }
        public bool CanUpdate()
        {
            return 
                //FirstName != Entity.FirstName
                //|| LastName != Entity.LastName
                //|| Email != Entity.Email
                //|| Passwd != Entity.Passwd
                //|| 
                IsAdmin != Entity.IsAdmin
                || IsActive != Entity.IsActive;
        }
        public void UpdateUser()
        {
            //string oldFirstName = Entity.FirstName;
            //string oldLastName = Entity.LastName;
            //string oldEmail = Entity.Email;
            //string oldPasswd = Entity.Passwd;
            bool oldIsAdmin = Entity.IsAdmin;
            bool oldIsActive = Entity.IsActive;

            //Entity.FirstName = FirstName;
            //Entity.LastName = LastName;
            //Entity.Email = Email;
            //Entity.Passwd = Passwd;
            Entity.IsAdmin = IsAdmin;
            Entity.IsActive = IsActive;

            if (!_userRepository.UpdateUserStatus(UserId, Entity))
            {
                //Entity.FirstName = oldFirstName;
                //Entity.LastName = oldLastName;
                //Entity.Email = oldEmail;
                //Entity.Passwd = oldPasswd;
                Entity.IsAdmin = oldIsAdmin;
                Entity.IsActive = oldIsActive;
            }
        }
        #endregion
    }
}
