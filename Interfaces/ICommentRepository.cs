using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICommentRepository<TEntity, T>
    {
        List<T> GetAllCommentByEvent(int eventId);
        T GetOneComment(int commentId);
        List<T> GetAllCommentByUser(int userId);
        TEntity CreateComment(TEntity entity);
        //bool UpdateComment(int commentId, TEntity entity);
        void DeleteComment(int commentId);
    }
}
