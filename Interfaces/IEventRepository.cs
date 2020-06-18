﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IEventRepository<TEntity>
    {
        List<TEntity> GetAllEvent();
        TEntity GetOneEvent(int eventId);
        TEntity CreateEvent(TEntity entity);
        bool UpdateEvent(int eventId, TEntity entity);
        void DeleteEvent(int eventId);
    }
}
