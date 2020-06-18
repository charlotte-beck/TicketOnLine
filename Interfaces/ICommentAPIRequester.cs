using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICommentAPIRequester<TEntity, T>
    {
        IEnumerable<T> GetAllCommentByEvent(int eventId);
        T GetOneComment(int commentId);
        IEnumerable<T> GetAllCommentByUser(int userId);
        TEntity CreateComment(TEntity entity);
        //bool UpdateComment(int commentId, TEntity entity);
        void DeleteComment(int commentId);
    }
}
