﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserRepository<TEntity>
    {
        void DeleteUser(int userId);
    }
}
