using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserAPIRequester<TEntity>
    {
        IEnumerable<TEntity> GetAllUser();
        TEntity GetOneUser(int userId);
        TEntity CreateUser(TEntity entity);
        bool UpdateUser(int userId, TEntity entity);
        void DeleteUser(int userId);

        TEntity GetOneUserWithToken(int userId, string token);
    }
}
