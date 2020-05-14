using Global;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repositories.GlobalRepositories
{
    public class UserRepository_Global : IUserRepository<User>
    {
        private static IUserRepository<User> _instance;
        public static IUserRepository<User> Instance
        {
            get
            {
                return _instance ?? (_instance = new UserRepository_Global());
            }
        }

        private SqlConnection _connection;
        public UserRepository_Global()
        {
            _connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DatabaseTicketOnLine"].ConnectionString);
            _connection.Open();
        }
        public void DeleteUser(int userId)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_DeleteUser";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("UserId", userId);
            command.ExecuteNonQuery();
        }
    }
}