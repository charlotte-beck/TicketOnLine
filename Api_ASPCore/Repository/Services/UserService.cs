using Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Repository.Services
{
    public class UserService : IUserRepository
    {
        private static IUserRepository _instance;
        public static IUserRepository Instance
        {
            get
            {
                return _instance ?? (_instance = new UserService());
            }
        }

        private SqlConnection _connection;
        public UserService()
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
