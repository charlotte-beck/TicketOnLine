using Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Global;

namespace Api_ASPCore.Repository.Services
{
    public class UserService : IUserRepository<User>
    {
        private static IUserRepository<User> _instance;
        public static IUserRepository<User> Instance
        {
            get
            {
                return _instance ?? (_instance = new UserService());
            }
        }

        private SqlConnection _connection;
        public UserService()
        {
            //_connection = new SqlConnection(
            //    ConfigurationManager.ConnectionStrings["DatabaseTicketOnLine"].ConnectionString);
            _connection = new SqlConnection(@"Data Source=FORMA-VDI1106\TFTIC;Initial Catalog=DatabaseTicketOnLine;Integrated Security=True");
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

        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();
            SqlCommand command = _connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.SP_GetUsers";

            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    users.Add(new User
                    {
                        UserId = (int)dr["UserId"],
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Passwd = dr["Passwd"].ToString(),
                        IsActive = (bool)dr["IsActive"],
                        IsAdmin = (bool)dr["IsAdmin"]
                    });
                }
            }
            return users;
        }

        public User GetOneUser(int userId)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SP_GetUser";
            command.CommandType = CommandType.StoredProcedure;
            User u = new User();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    u.UserId = (int)dr["UserId"];
                    u.FirstName = dr["FirstName"].ToString();
                    u.LastName = dr["LastName"].ToString();
                    u.Email = dr["Email"].ToString();
                    u.Passwd = dr["Passwd"].ToString();
                    u.IsAdmin = (bool)dr["IsAdmin"];
                    u.IsActive = (bool)dr["IsActive"];
                }
            }
            return u;
        }

        public User CreateUser(User entity)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_CreateUser";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("FirstName", entity.FirstName);
            command.Parameters.AddWithValue("LastName", entity.LastName);
            command.Parameters.AddWithValue("Email", entity.Email);
            command.Parameters.AddWithValue("Passswd", entity.Passwd);
            command.Parameters.AddWithValue("IsAdmin", entity.IsAdmin);
            command.Parameters.AddWithValue("IsActive", entity.IsActive);
            entity.UserId = (int)command.ExecuteScalar();
            return entity;
            //command.ExecuteNonQuery();

        }

        public bool UpdateUser(int userId, User entity)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_UpdateUser";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("UserId", userId);
            command.Parameters.AddWithValue("FirstName", entity.FirstName);
            command.Parameters.AddWithValue("LastName", entity.LastName);
            command.Parameters.AddWithValue("Email", entity.Email);
            command.Parameters.AddWithValue("Passswd", entity.Passwd);
            command.Parameters.AddWithValue("IsAdmin", entity.IsAdmin);
            command.Parameters.AddWithValue("IsActive", entity.IsActive);
            return command.ExecuteNonQuery() == 1;
        }

        public bool UpdateUserStatus(int userId, User entity)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_UpdateUserActiveOrAdmin";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("UserId", userId);
            command.Parameters.AddWithValue("IsAdmin", entity.IsAdmin);
            command.Parameters.AddWithValue("IsActive", entity.IsActive);
            return command.ExecuteNonQuery() == 1;
        }
    }
}