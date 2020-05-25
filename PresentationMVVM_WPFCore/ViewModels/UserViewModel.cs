using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using Repositories;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToolBox.Patterns.Messenger;

namespace PresentationMVVM_WPFCore.ViewModels
{
    //public class UserViewModel : ViewModelCollectionBase<UserDetailViewModel>
    //{
    //    private UserRepository _userRepository;
    //    private User _entity;

    //    //public UserViewModel()
    //    //{
    //    //    _userRepository = new UserRepository("https://localhost:5001/api/");
    //    //    Messenger<UserDetailViewModel>.Instance.Register("UserDelete", OnDeleteUser);
    //    //}
    //    private void OnDeleteUser(UserDetailViewModel instance)
    //    {
    //        Items.Remove(instance);
    //    }

    //    //protected override ObservableCollection<UserDetailViewModel> LoadItems()
    //    //{
    //    //    ObservableCollection<UserDetailViewModel> users =
    //    //        new ObservableCollection<UserDetailViewModel>(_userRepository.GetAllUser()
    //    //        .Select(x => new UserDetailViewModel(x)));
    //    //    return users;
    //    //}
    //}
}
