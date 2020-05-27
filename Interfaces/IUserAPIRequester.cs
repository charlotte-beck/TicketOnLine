﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserAPIRequester<TEntity>
    {
        IEnumerable<TEntity> GetAllUser();
        TEntity GetOneUser(int userId);
        void CreateUser(TEntity entity);
        bool UpdateUser(int userId, TEntity entity);
        void DeleteUser(int userId);

        bool UpdateUserStatus(int userId, TEntity entity);
    }
}