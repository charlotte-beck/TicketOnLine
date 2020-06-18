using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using PresentationMVVM_WPFCore.Views;
using Repositories;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public string FirstName
        {
            get { return Entity.FirstName; }
        }

        public string LastName
        {
            get { return Entity.LastName; }
        }

        public string Email
        {
            get { return Entity.Email; }
        }

        public string Passwd
        {
            get { return Entity.Passwd; }
        }

        public string Token
        {
            get { return Entity.Token; }
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
            IsActive = Entity.IsActive;
            IsAdmin = Entity.IsAdmin;
            _userRepository = new UserRepository("http://localhost:56586/api/");
        }

        #region Command Update

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

            _userRepository.UpdateUser(UserId, Entity);
            UpdateCommand.RaiseCanExecuteChanged();

            if (!_userRepository.UpdateUser(UserId, Entity))
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

        #region Command

        //private RelayCommand _detailsCommand;
        //public RelayCommand DetailsCommand
        //{
        //    get
        //    {
        //        return _detailsCommand ?? (_detailsCommand = new RelayCommand(ShowDetails));
        //    }
        //}
        //private void ShowDetails()
        //{
        //    UserDetailsWindow udw = new UserDetailsWindow();
        //    udw.DataContext = this;

        //    udw.Show();
        //    //_userRepository.GetOneUser(UserId);
        //}

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
        #endregion
    }
}