using PresentationMVVM_WPFCore.Utils.Command;
using PresentationMVVM_WPFCore.Utils.Mappers;
using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using Repositories.APIRequester;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;
using ToolBox.Patterns.Messenger;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class CommentDetailViewModel : EntityViewModelBase<Comment_User_Event>
    {
        private CommentRequester _commentRepository;
        public CommentDetailViewModel(Comment_User_Event entity) : base(entity)
        {
            _commentRepository = new CommentRequester("http://localhost:56586/api/");
            CommentContent = Entity.CommentContent;
        }

        #region Properties
        public int CommentId
        {
            get { return Entity.CommentId; }
        }

        public int UserId
        {
            get { return Entity.UserId; }
        }

        public int EventId
        {
            get { return Entity.EventId; }
        }

        public string User
        {
            get { return Entity.User; }
        }

        public string Event
        {
            get { return Entity.Event; }
        }

        public DateTime CommentDate
        {
            get { return Entity.CommentDate; }
        }

        private string _commentContent;
        public string CommentContent
        {
            get { return _commentContent; }
            set
            {
                if (_commentContent != value)
                {
                    _commentContent = value;
                    RaisePropertyChanged(nameof(CommentContent));
                }
            }
        }
        #endregion

        #region Command Delete
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
            _commentRepository.DeleteComment(CommentId);
            Messenger<Comment_User_Event>.Instance.Send(Entity);
        }
        #endregion

        #region Command Details
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
            _commentRepository.GetOneComment(CommentId);
        }
        #endregion

        #region Command Update (pas finie)
        //private RelayCommand _updateCommand;
        //public RelayCommand UpdateCommand
        //{
        //    get
        //    {
        //        return _updateCommand ?? (_updateCommand = new RelayCommand(UpdateComment, CanUpdate));
        //    }
        //}
        //public bool CanUpdate()
        //{
        //    return
        //        CommentContent != Entity.CommentContent;
        //}
        //public void UpdateComment()
        //{
        //    string oldCommentContent = Entity.CommentContent;


        //    Entity.CommentContent = CommentContent;

        //    if (!_commentRepository.UpdateComment(CommentId, Entity.ToWpf()))
        //    {
        //        Entity.CommentContent = oldCommentContent;
        //        Messenger<Comment_User_Event>.Instance.Send(Entity);
        //    }


        //}
        #endregion
    }
}