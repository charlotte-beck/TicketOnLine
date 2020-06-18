using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserRepository<TEntity>
    {
        List<TEntity> GetAllUser();
        TEntity GetOneUser(int userId);
        TEntity CreateUser(TEntity entity);
        bool UpdateUser(int userId, TEntity entity);
        void DeleteUser(int userId);
    }
}
