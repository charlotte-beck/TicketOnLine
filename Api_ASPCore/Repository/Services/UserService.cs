using Api_ASPCore.Models.Data;
using Interfaces;
using Repositories.GlobalRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Repository.Services
{
    public class UserService : IUserRepository<User>
    {
        private static IUserRepository<User> _instance;
        public static IUserRepository<User> Instance
        {
            get { return _instance ?? (_instance = new UserService()); }
        }
        public void DeleteUser(int userId)
        {
            UserRepository_Global.Instance.DeleteUser(userId);
        }
    }
}
