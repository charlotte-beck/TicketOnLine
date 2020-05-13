using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IEventRepository<TEntity>
    {
        List<TEntity> GetAllEvent();
        TEntity GetOneEvent(int eventId);
        IEnumerable<TEntity> GetAllByUser(int userId);
        TEntity GetOneByUser(int userId, int eventId);
        TEntity CreateEvent(TEntity entity);
        void UpdateEvent(int eventId, TEntity entity);
        void DeleteEvent(int eventId);
    }
}
