﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IEventRepository<TEntity>
    {
        List<TEntity> GetAllEvent();
        TEntity GetOneEvent(int eventId);
        List<TEntity> GetAllByUser(int userId);
        TEntity GetOneByUser(int userId, int eventId);
        void CreateEvent(TEntity entity);
        void UpdateEvent(int eventId, TEntity entity);
        void DeleteEvent(int eventId);
    }
}
