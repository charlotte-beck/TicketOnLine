using PresentationMVVM_WPFCore.ViewModels.ViewModelsBase;
using Repositories.APIRequester;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ToolBox.Patterns.Messenger;

namespace PresentationMVVM_WPFCore.ViewModels
{
    public class CommentByEventViewModel : ViewModelCollectionBase<CommentDetailViewModel>
    {
        #region Properties
        private int _userId, _eventId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }

        private string _user, _event;
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }
        private DateTime _commentDate;
        public DateTime Date
        {
            get { return _commentDate; }
            set { _commentDate = value; }
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

        private CommentRequester _commentRepository;
        public CommentByEventViewModel(int eventId)
        {
            this.EventId = eventId;
            _commentRepository = new CommentRequester("http://localhost:56586/api/");
            Messenger<Comment_User_Event>.Instance.Register(OnDeleteComment);
            //eventId = EventId;
        }

        private void OnDeleteComment(Comment_User_Event c)
        {
            CommentDetailViewModel commentDetailViewModel = new CommentDetailViewModel(c);
            Items = LoadItems();
        }

        protected override ObservableCollection<CommentDetailViewModel> LoadItems()
        {
            ObservableCollection<CommentDetailViewModel> comments =
                new ObservableCollection<CommentDetailViewModel>(_commentRepository.GetAllCommentByEvent(EventId)
                .Select(x => new CommentDetailViewModel(x)));
            return comments;
        }
    }
}
